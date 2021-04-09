from entidades_mock import *
from lib import *
import time
import autoit


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

    def test_filtro_busca(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_id("Filtros_Titulo").send_keys(Livro().titulo)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de titulo.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Filtros_Autor").send_keys(Livro().autor)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de Autor.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Filtros_Isbn").send_keys(Livro().ISBN)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de Isbn.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Filtros_Editora").send_keys(Livro().editora)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de Editora.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Filtros_PrecoMin").send_keys(Livro().preco_minimo)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de PrecoMin.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Filtros_PrecoMax").send_keys(Livro().preco_maximo)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de PrecoMax.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("dataMin").send_keys(Livro().data_min)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de dataMin.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Filtros_Categoria").click()
                browser.find_element_by_xpath("/html/body/div/main/div/div/div/div[1]/form/div/div[6]/div/select/option[4]").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o input de Filtros_Categoria.")

        Mbox(text="Preencheu filtro de busca.")

    def test_click_saiba_mais(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                btns = browser.find_elements_by_tag_name("button")
                for btn in btns:
                    texto_btn = btn.get_attribute("innerText")
                    if texto_btn == "SAIBA MAIS":
                        btn.click()
                        break
                else:
                    continue
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o btn SAIBA MAIS.")
        Mbox(text="Clicou em SAIBA MAIS.")

        assert browser.title == "Descrição - SóRaiva"

    def test_click_compra_agora(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                btns = browser.find_elements_by_tag_name("button")
                for btn in btns:
                    texto_btn = btn.get_attribute("innerText")
                    if texto_btn == "COMPRAR AGORA":
                        btn.click()
                        break
                else:
                    continue
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o btn COMPRAR AGORA.")
        Mbox(text="Clicou em COMPRAR AGORA.")
        assert browser.title == "FinalizarCompra - SóRaiva"

    def test_escolhe_cupom(self):  #buttonCupom
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_id("buttonCupom").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o botão dos cupons.")

        time.sleep(3)

        timer.reset()
        while timer.not_expired:
            try:
                btns = browser.find_elements_by_tag_name("button")
                for btn in btns:
                    texto_btn = btn.get_attribute("innerText")
                    if texto_btn == "Usar este cupom":
                        btn.click()
                        break
                else:
                    continue
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o btn do cupom.")
        Mbox(text="Escolheu o cupom.")

    def test_adiciona_cartao(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_id("buttonCartao").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o botão buttonCartao.")
        time.sleep(3)
        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Nome").send_keys(Cartao().nome)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de nome do cartão.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Bandeira").click()
                browser.find_element_by_xpath('//*[@id="Bandeira"]/option[2]').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o select de bandeira do cartão.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Codigo").send_keys(Cartao().codigo)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de código do cartão.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Cvv").send_keys(Cartao().cvv)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de cvv do cartão.")

        timer.reset()
        while timer.not_expired:
            try:
                vencimento = browser.find_element_by_id("Vencimento")
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de cvv do cartão.")
        vencimento.send_keys(Cartao().mes)
        time.sleep(1)
        autoit.send("{TAB}")
        time.sleep(1)
        vencimento.send_keys(Cartao().ano)
        Mbox(text="Preencheu novo cartão.")
        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("btn").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não clicou em cadastrar cartão.")

    def test_preenche_endereco(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_id("buttonEndereco").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o botão dos cupons.")
        time.sleep(3)
        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("NomeEndereco").send_keys(Endereco().nome)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de nome do endereço.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Logradouro").send_keys(Endereco().logradouro)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de logradouro.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Numero").send_keys(Endereco().numero)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de Numero.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Complemento").send_keys(Endereco().complemento)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de complemento.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Cep").send_keys(Endereco().cep)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de Cep.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Cidade").send_keys(Endereco().cidade)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de Cidade.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Estado").send_keys(Endereco().estado)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de Estado.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("Pais").send_keys(Endereco().pais)
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o campo de Pais.")

        timer.reset()
        while timer.not_expired:
            try:
                labels = browser.find_elements_by_tag_name("label")
                for label in labels:
                    texto_label = label.get_attribute("innerText")
                    if texto_label == "É endereço de entrega?":
                        label.click()
                        break
                else:
                    continue
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou o label de endereço de entrega.")
        Mbox(text="Preencheu novo endereço de entrega.")
        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id("btn").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não clicou em cadastrar endereço.")

    def test_acessar_so_raiva_administrado(self):
        browser = ChromeBrowser().aberto()
        browser.get("https://localhost:44378/Admin/Home")
        titulo = browser.title
        Mbox(text="Fim acessa home dos administrador.")
        assert titulo == "View - SóRaiva"

    def test_acessar_clientes(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                tags_a = browser.find_elements_by_tag_name("a")
                for a in tags_a:
                    texto_a = a.get_attribute("innerText")
                    if texto_a == "Clientes":
                        a.click()
                        break
                else:
                    continue
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou clientes.")
        Mbox(text="Fim acessa clientes.")

    def test_inativa_cliente(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_xpath("/html/body/div/main/div[3]/table/tbody/tr[1]/td[4]/button").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou clientes.")

        time.sleep(7)

        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="myModal"]/div/div/div[2]/div[2]/button[2]').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou botão cancelar.")

        Mbox(text="Fim inativa clientes.")

    def test_visualiza_cliente(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_xpath("/html/body/div/main/div[3]/table/tbody/tr[1]/td[3]/button").click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn visualizar.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="sidebar"]/div[2]/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn telefones.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="sidebar"]/div[3]/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn endereços.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="sidebar"]/div[4]/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn Cartões de Crédito.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="sidebar"]/div[5]/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn historia de compras.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="sidebar"]/div[6]/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn cupons.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="myModal"]/div/div/div[1]/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn cancelar.")

        Mbox(text="Fim visualiza clientes.")

    def test_visualiza_pedidos(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="navbarSupportedContent"]/ul[2]/li[3]/a').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn pedidos.")

        time.sleep(3)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="corpoTabela"]/tr[1]/td[5]/button[2]').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn visualizar.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="myModal"]/div[2]/div/div[2]/div[2]/div/div/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou btn cancelar.")

        Mbox(text="Fim visualiza pedidos.")

    def test_acessa_config(self):
        browser = ChromeBrowser().aberto()
        timer = Timer(15)
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="navbarSupportedContent"]/ul[2]/li[4]/a').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou menu de configurações da loja.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="Livros"]/div[1]/div/button').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou cadastro de livro.")

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_id('Livro_Titulo').send_keys(Livro().titulo)
                browser.find_element_by_id('Livro_Autor').send_keys(Livro().autor)
                browser.find_element_by_id('Livro_Editora').send_keys(Livro().editora)
                browser.find_element_by_id('Livro_Edicao').send_keys(Livro().edicao)
                browser.find_element_by_id('Livro_Isbn').send_keys(Livro().ISBN)
                browser.find_element_by_id('Livro_Paginas').send_keys(Livro().paginas)
                browser.find_element_by_id('Livro_Comprimento').send_keys(Livro().dimencao)
                break
            except Exception as e:
                continue
        if timer.expired:
            print("Timeout. Não achou campo de título.")

        time.sleep(5)

        timer.reset()
        while timer.not_expired:
            try:
                browser.find_element_by_xpath('//*[@id="myModal"]/div/div/div[2]/form/div[2]/button[2]').click()
                break
            except:
                continue
        if timer.expired:
            print("Timeout. Não achou botão de cadastrar livro.")

        Mbox(text="Fim acessa configurações.")



if __name__ == '__main__':
    # TestSoRaiva().test_acessar_so_raiva()
    # TestSoRaiva().test_acessar_livros()
    # TestSoRaiva().test_filtro_busca()
    # TestSoRaiva().test_click_saiba_mais()
    # TestSoRaiva().test_click_compra_agora()
    # TestSoRaiva().test_escolhe_cupom()
    # TestSoRaiva().test_adiciona_cartao()
    # TestSoRaiva().test_preenche_endereco()
    TestSoRaiva().test_acessar_so_raiva_administrado()
    TestSoRaiva().test_acessar_clientes()
    TestSoRaiva().test_inativa_cliente()
    TestSoRaiva().test_visualiza_cliente()
    TestSoRaiva().test_visualiza_pedidos()
    TestSoRaiva().test_acessa_config()