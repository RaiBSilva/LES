from unittest import TestCase
from lib import *


class TestSoRaiva():
    def test_acessar_so_raiva(self):
        browser = ChromeBrowser().novo()
        browser.get("https://localhost:44378/")
        titulo = browser.title
        Mbox(text="Fim acessa livraria.")
        assert titulo == "Home Page - SóRaiva"

    def test_acessar_livros(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_id("aLivros").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o menu Livros.")
        Mbox(text="Fim acessa livro.")
        titulo = browser.title
        assert titulo == "SóRaiva Livros - SóRaiva"


if __name__ == '__main__':
    TestSoRaiva().test_acessar_so_raiva()
    TestSoRaiva().test_acessar_livros()