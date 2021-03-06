import time
import json
from selenium import webdriver
import ctypes
from pyautogui import locateCenterOnScreen
import pyautogui as pyg
import autoit
import os



class Window:
    def __init__(self, title):
        self.title = title

    def activate_window(self, *, timeout=15):
        # Retorno 0   --Tela encontrada
        # Retorno -1  --Timeout

        timer = Timer(timeout)
        while timer.not_expired:
            try:
                autoit.win_activate(self.title)
                return 0
            except Exception as e:
                #print(f"[Exception]--> {e}")
                pass
        if timer.expired:
            return -1

    def control(self):
        return self.Control(props=self, title=self.title)

    class Control:
        def __init__(self, props, *, title):
            self.props = props
            self.title = title

        def set_text(self, txt:str, control:str, *, timeout=15, focus=True):
            timer = Timer(timeout)
            while timer.not_expired:
                try:
                    if focus:
                        autoit.control_focus(self.title, control)
                    autoit.control_set_text(self.title, control, txt)
                    return 0
                except Exception as e:
                    # print(f"[Exception]--> {e}")
                    pass
            if timer.expired:
                return -2

        def get_text(self, control:str, *, timeout=15, focus=True):
            ctrl_txt = None
            timer = Timer(timeout)
            while timer.not_expired:
                try:
                    if focus:
                        autoit.control_focus(self.title, control)
                    ctrl_txt = autoit.control_get_text(self.title, control)
                    if isinstance(ctrl_txt, str):
                        return ctrl_txt
                except Exception as e:
                    # print(f"[Exception]--> {e}")
                    pass
            if timer.expired:
                return -1

        def click(self, control:str, *, timeout=15, focus=True):
            timer = Timer(timeout)
            while timer.not_expired:
                try:
                    if focus:
                        autoit.control_focus(self.title, control)
                    autoit.control_click(self.title, control)
                    return 0
                except Exception as e:
                    # print(f"[Exception]--> {e}")
                    pass
            if timer.expired:
                return -1
            
            
            
def Mbox(*, title="Teste", text, style=1):
    return ctypes.windll.user32.MessageBoxW(0, text, title, style)


class Timer:
    def __init__(self, duration=10):
        self.duration = float(duration)
        self.start = time.perf_counter()
        
    def reset(self):
        self.start = time.perf_counter()

    def explode(self):
        self.duration = 0

    def increment(self, increment=0):
        self.duration += increment
        
    @property
    def not_expired(self):
        if self.duration == -1:
            return True
        return False if time.perf_counter() - self.start > self.duration else True

    @property
    def expired(self):
        return not self.not_expired

    @property
    def at(self):
        return time.perf_counter() - self.start
    
    
class Image:
    def __init__(self, img_path, *, confidence=0.95):
        if not os.path.isfile(img_path):
            raise Exception(f"Caminho não é um arquivo válido: {img_path}")
        self.image_path = img_path
        self.accuracy = confidence

    def find(self):
        position = None
        try:
            position = locateCenterOnScreen(self.image_path, confidence=self.accuracy)
            if position is not None:
                position = (position[0], position[1])
        except Exception as e:
            pass
        return position

    def wait_image(self, *, timeout=10, rtn_pos=True):
        start = time.perf_counter()
        while True:
            if time.perf_counter() - start > timeout:
                return -1
            rtn_find = self.find()
            if rtn_find is not None:
                if rtn_pos:
                    return rtn_find
                else:
                    return 0

    def click(self, *, btn="left", clicks=1, x=0, y=0):
        return self.Click(props=self, btn=btn, clicks=clicks, x=x, y=y)

    class Click:
        def __init__(self, *, props, btn, clicks, x, y):
            self.props = props
            self.button = btn
            self.clicks = clicks
            self.pos_x = x
            self.pos_y = y

        def execute(self):
            rtn_pos = self.props.find()
            if rtn_pos is not None:
                pyg.click(rtn_pos[0]+self.pos_x, rtn_pos[1]+self.pos_y, button=self.button, clicks=self.clicks)
                return 0
            else:
                return -1

        def wait_ready(self, timeout=15):
            rtn_pos = self.props.wait_image(timeout=timeout)
            if isinstance(rtn_pos, tuple):
                pyg.click(rtn_pos[0] + self.pos_x, rtn_pos[1] + self.pos_y, button=self.button, clicks=self.clicks)
                return 0
            else:
                return -1


class ChromeBrowser:
    def __init__(self):
        self.chrome_id = "chrome_id.json"
        self.chrome_exe = r"D:\DESENVOLVIMENTO\WebDrivers\chromedriver.exe"

    def new(self):
        global driver
        driver = webdriver.Chrome(executable_path=self.chrome_exe)
        try:
            driver.maximize_window()
        except:
            pass
        url = driver.command_executor._url
        session_id = driver.session_id
        dados = {
            'url': url,
            'session_id': session_id
        }
        with open(self.chrome_id, 'w') as json_file:
            json.dump(dados, json_file, indent=4)

        return driver

    def opened(self, open_new=True):
        tem_id = True
        with open(self.chrome_id, 'r') as json_file:
            try:
                chrome_info = json.load(json_file)
            except:
                tem_id = False
        if tem_id:
            id = chrome_info["session_id"]
            url = chrome_info["url"]
            try:
                driver = webdriver.Remote(command_executor=url, desired_capabilities={})
                driver.close()
                driver.session_id = id
                for handle in driver.window_handles:
                    driver.switch_to.window(handle)
                    break
                return driver
            except:
                return self.new() if open_new else -1
        return self.new() if open_new else -1

    def kill(self):
        driver = self.opened()
        driver.close()