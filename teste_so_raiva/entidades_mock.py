class Livro:
    def __init__(self):
        self.titulo = "Harry Potter e a pedra filosofal"
        self.autor = "J.K. Rowling"
        self.ISBN = "8532530788"
        self.editora = "Rocco"
        self.preco_maximo = "40.00"
        self.preco_minimo = "31.00"
        self.categoria = "Fantasia"
        self.data_min = "19082007"
        self.data_max = "19082020"
        self.edicao = "10"
        self.paginas = "20000"
        self.dimencao = "10"


class Cartao:
    def __init__(self):
        self.nome = "Joseph Joestar"
        self.codigo = "1234567891231234"
        self.cvv = "420"
        self.mes = "maio"
        self.ano = "2027"


class Endereco:
    def __init__(self):
        self.nome = "Simas Turbo Oficina Mecânica"
        self.logradouro = "Av. Eugen Wissmann"
        self.numero = "271"
        self.cep = "13304-270"
        self.cidade = "São Luiz, Itu"
        self.estado = "SP"
        self.pais = "Brasil"
        self.complemento = "Perto do mercado."