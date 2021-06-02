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
        self.nome = "John Price"
        self.codigo = "1234567891231234"
        self.cvv = "420"
        self.mes = "maio"
        self.ano = "2027"
        self.mastercard = "Mastercard"
        
        
class Cartao2:
    def __init__(self):
        self.nome = "John Price"
        self.codigo = "1235567891239999"
        self.cvv = "253"
        self.mes = "maio"
        self.ano = "2026"
        self.mastercard = "Visa"


class Endereco:
    def __init__(self):
        self.nome = "Toreto Oficina Mecânica"
        self.logradouro = "Av. Eugen Wissmann"
        self.numero = "271"
        self.cep = "13304270"
        self.cidade = "São Luiz, Itu"
        self.estado = "SP"
        self.pais = "Brasil"
        self.complemento = "Perto do mercado."
        self.observacoes = "Casa B, na esquerda."
        

class User:
    def __init__(self):
        self.nome = "John Price"
        self.data_nascimento = "12081996"
        self.cpf = "42069024185"
        self.email = "john6dark@gmail.com"
        self.senha = "CODww@supax"
        self.ddd = "011"
        self.telefone = "942458998"
        
        
class UserSuper:
    def __init__(self):
        self.nome = "John Price"
        self.data_nascimento = "12081996"
        self.cpf = "42069024100"
        self.email = "admin@admin"
        self.senha = "ABCabc123!"
        self.ddd = "011"
        self.telefone = "942458998"
        