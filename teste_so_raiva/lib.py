import time
import json
from selenium import webdriver
import ctypes


def Mbox(*, title="Teste", text, style=1):
    return ctypes.windll.user32.MessageBoxW(0, text, title, style)


class Timer:
    def __init__(self, duration=10):
        self.duration = float(duration)
        self.start = time.perf_counter()
        # print("The timer has started. Self.start: " + str(self.start))

    def reset(self):
        self.start = time.perf_counter()
        # print("The timer has been reset. Self.start: " + str(self.start))

    def explode(self):
        self.duration = 0
        # print("The timer has been force-expired.")

    def increment(self, increment=0):
        self.duration += increment
        # print("The timer has been incremented by " + str(increment) + " seconds")

    @property
    def not_expired(self):
        # duration == -1 means dev wants a infinite loop/Timer
        if self.duration == -1:
            return True
        return False if time.perf_counter() - self.start > self.duration else True

    @property
    def expired(self):
        return not self.not_expired

    @property
    def at(self):
        # print("The timer is running. Self.at: " + str(time.perf_counter() - self.start))
        return time.perf_counter() - self.start


class ChromeBrowser:
    def __init__(self):
        self.chrome_id = "chrome_id.json"
        self.chrome_exe = r"D:\DEVELOPMENT\WebDrivers\chromedriver.exe"

    def novo(self):
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

    def aberto(self):
        tem_id = True
        with open(self.chrome_id, 'r') as json_file:
            try:
                chrome_info = json.load(json_file)
            except Exception as e:
                print(e)
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
                return self.novo()
        return self.novo()

    def fechar(self):
        driver = self.aberto()
        driver.close()