import mysql.connector

# Conecta-se ao banco de dados
conexao = mysql.connector.connect(
  host='localhost',
  user='root',
  password='aluno',
  database='switchcase'
)

# Executa a consulta SQL para obter os dados da tabela
cursor = conexao.cursor()
cursor.execute('SELECT corrente FROM correntes')
dados = cursor.fetchall()

# Calcula a soma dos valores
total = sum([valor[0] for valor in dados])

# Exibe o total
print('Total:', total)

# Fecha a conexão com o banco de dados
cursor.close()
conexao.close()