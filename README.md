# Instalação e Configuração do SQL Server Management Studio (SSMS) e LocalDB

## 1. Download e Instalação do SSMS

**Acesse a Página de Download:**
   - Visite a página oficial da Microsoft para baixar o SSMS:  
     [Download SSMS](https://aka.ms/ssmsfullsetup)

## 2. Configurando e Utilizando o LocalDB

### Conectando ao LocalDB no SSMS

1. **Abrir o SSMS:**
   - Inicie o SQL Server Management Studio.

2. **Conectar à Instância LocalDB:**
   - Na janela de conexão, preencha o campo **Nome do servidor** com:
     ```
     (localdb)\MSSQLLocalDB
     ```
     > **Dica:** O nome padrão da instância LocalDB é "MSSQLLocalDB". Se você tiver outras instâncias, utilize o nome correto conforme listado.
   
   - Selecione a opção de **Autenticação do Windows** (geralmente a padrão) e clique em **Conectar**.
---

# Exemplo Básico de SQL: Escola e Tabela Alunos

## 1. Criar o Banco de Dados

Primeiro, criamos o banco de dados chamado **Escola**:

```sql
CREATE DATABASE Escola;
```

> **Descrição:** Cria o banco de dados "Escola" onde serão armazenadas as tabelas.

---

## 2. Deletar o Banco de Dados

Caso seja necessário remover o banco de dados, use o comando:

```sql
DROP DATABASE Escola;
```

> **Descrição:** Remove completamente o banco de dados "Escola" e todas as tabelas e dados que ele contém.

---

## 3. Usar o Banco de Dados

Para começar a trabalhar com o banco de dados criado, é preciso selecioná-lo:

```sql
USE Escola;
```

> **Descrição:** Seleciona o banco de dados "Escola" para que os comandos subsequentes sejam executados nele.

---

## 4. Criar a Tabela Alunos

Dentro do banco de dados "Escola", crie a tabela **alunos**:

```sql
CREATE TABLE alunos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    idade INT,
    email VARCHAR(100)
);
```

> **Descrição:** Cria a tabela "alunos" com as colunas:
> - `id`: identificador único do aluno (chave primária e auto-incrementável);
> - `nome`: nome do aluno (não pode ser nulo);
> - `idade`: idade do aluno;
> - `email`: email do aluno.

---

## Sequência de Execução dos Comandos

Para praticar e executar os comandos na ordem correta, siga os passos abaixo:

1. **Criar o Banco de Dados:**  
   Execute o comando:
   ```sql
   CREATE DATABASE Escola;
   ```
   
2. **Selecionar o Banco de Dados:**  
   Execute o comando:
   ```sql
   USE Escola;
   ```

3. **Criar a Tabela Alunos:**  
   Execute o comando:
   ```sql
   CREATE TABLE alunos (
       id INT PRIMARY KEY AUTO_INCREMENT,
       nome VARCHAR(100) NOT NULL,
       idade INT,
       email VARCHAR(100)
   );
   ```
   
4. **(Opcional) Deletar o Banco de Dados:**  
   Se precisar remover o banco de dados e todos os dados, execute:
   ```sql
   DROP DATABASE Escola;
   ```

---

## 1. Alterando a Tabela Alunos

### a) Adicionar Novos Campos

Adicione, por exemplo, os campos **endereco** e **telefone**:

```sql
ALTER TABLE alunos
ADD endereco VARCHAR(200),
    telefone VARCHAR(20);
```

> **Descrição:** Esse comando adiciona as colunas `endereco` e `telefone` à tabela **alunos**.

---

### b) Remover um Campo

Suponha que você deseje remover o campo **email**:

```sql
ALTER TABLE alunos
DROP COLUMN email;
```

> **Descrição:** Esse comando remove a coluna `email` da tabela **alunos**.

---

### c) Alterar a Definição de um Campo

Para mudar a definição do campo **nome** de `VARCHAR(100)` para `VARCHAR(150)`, utilize:

```sql
ALTER TABLE alunos
ALTER COLUMN nome VARCHAR(150) NOT NULL;
```

> **Descrição:** Esse comando altera o tamanho da coluna `nome` para 150 caracteres, mantendo a restrição de não permitir valores nulos.

---

## 2. Inserindo Dados na Tabela Alunos

Após as alterações, insira alguns registros na tabela:

```sql
INSERT INTO alunos (nome, idade, endereco, telefone)
VALUES ('Ana Silva', 22, 'Rua das Flores, 123', '11987654321'),
       ('Bruno Souza', 19, 'Av. Paulista, 456', '11912345678');
```

> **Descrição:** Insere dois registros na tabela **alunos** com os campos `nome`, `idade`, `endereco` e `telefone`.

---

## 3. Consultas Simples

### a) Buscar Todos os Dados

Para exibir todos os registros da tabela:

```sql
SELECT * FROM alunos;
```

> **Descrição:** Seleciona e exibe todas as colunas de todos os registros da tabela **alunos**.

---

### b) Buscar Dados com Filtro por Idade

Exemplo para buscar alunos com idade maior que 20:

```sql
SELECT * FROM alunos
WHERE idade > 20;
```

> **Descrição:** Retorna os registros onde a idade dos alunos é superior a 20.

---

### c) Buscar Dados Utilizando o Operador LIKE

Exemplo para buscar alunos cujo nome comece com a letra "A":

```sql
SELECT * FROM alunos
WHERE nome LIKE 'A%';
```

> **Descrição:** Seleciona os registros em que o nome do aluno inicia com "A".

---

### d) Buscar Alunos cujo Nome Termine com "Silva"

Utilize o caractere curinga `%` para indicar qualquer sequência de caracteres antes da palavra "Silva".

```sql
SELECT * FROM alunos
WHERE nome LIKE '%Silva';
```

> **Explicação:**  
> O símbolo `%` substitui qualquer sequência de caracteres (inclusive nenhuma). Dessa forma, a condição busca por nomes que terminem exatamente com "Silva", independentemente do que venha antes.

---

### e) Buscar Alunos cujo Nome Contenha "Silva"

Novamente, o `%` é usado antes e depois da palavra, permitindo que "Silva" apareça em qualquer parte do nome.

```sql
SELECT * FROM alunos
WHERE nome LIKE '%Silva%';
```

> **Explicação:**  
> Essa consulta retorna todos os registros onde "Silva" aparece em qualquer posição dentro do campo `nome`.

---

### f) Buscar Alunos cujo Nome Comece com "A" e Termine com "a"

Neste exemplo, usamos `%` para representar qualquer sequência de caracteres entre a letra inicial "A" e a letra final "a".

```sql
SELECT * FROM alunos
WHERE nome LIKE 'A%a';
```

> **Explicação:**  
> Aqui, o padrão procura por nomes que comecem com "A", tenham qualquer sequência de caracteres no meio e terminem com "a".  
> *Exemplo:* "Ana", "Amanda" e "Allegra" seriam correspondentes, desde que a última letra seja "a".

---

### g) Buscar Alunos cujo Nome Possua um Padrão Específico com o Underscore (_)

O caractere `_` substitui exatamente um caractere. Esse exemplo busca por nomes que tenham exatamente cinco caracteres.

```sql
SELECT * FROM alunos
WHERE nome LIKE '_____';
```

> **Explicação:**  
> Cada `_` representa um caractere único. Assim, a consulta retornará apenas nomes com exatamente cinco caracteres.  
> *Exemplo:* Se existir um aluno com o nome "Maria" (5 letras), ele será retornado.

---

### h) Buscar Alunos cujo Nome Não Comece com "B"

Utilize o operador `NOT LIKE` para excluir registros que seguem um determinado padrão.

```sql
SELECT * FROM alunos
WHERE nome NOT LIKE 'B%';
```

> **Explicação:**  
> Essa consulta retorna todos os registros em que o nome **não** inicia com a letra "B".  
> *Exemplo:* "Ana", "Carlos" e "Diana" serão exibidos, mas nomes como "Bruno" serão excluídos.

---

### i) Combinação de Operadores com LIKE e Outros Filtros

Você pode combinar o operador **LIKE** com outras condições utilizando `AND` ou `OR`. Por exemplo, para buscar alunos cujo nome contenha "a" (ignorando caixa, se o collation do banco for case-insensitive) e que tenham idade maior ou igual a 18:

```sql
SELECT * FROM alunos
WHERE nome LIKE '%a%' AND idade >= 18;
```

> **Explicação:**  
> Essa consulta retorna os alunos que possuem a letra "a" em qualquer posição do nome **e** cuja idade seja maior ou igual a 18.  
> Esse tipo de filtro é útil para realizar buscas mais específicas combinando critérios de texto e numéricos.

---

### j) Buscar Alunos Utilizando Múltiplos Padrões com OR

Se desejar buscar alunos que atendam a um ou outro padrão, você pode usar o operador `OR`. Por exemplo, buscar alunos cujo nome comece com "A" **ou** termine com "o":

```sql
SELECT * FROM alunos
WHERE nome LIKE 'A%' OR nome LIKE '%o';
```

> **Explicação:**  
> A consulta retorna registros que satisfaçam **pelo menos uma** das condições: nomes iniciando com "A" ou nomes terminando com "o".  
> Essa abordagem amplia o escopo da busca para incluir diferentes padrões em uma única consulta.

---

Esses exemplos demonstram como o operador **LIKE** pode ser utilizado de forma flexível para filtrar resultados baseando-se em padrões de texto, assim como sua combinação com outros operadores e condições para refinar as buscas. Esses comandos são especialmente úteis em ambientes onde se trabalha com dados textuais e se deseja encontrar registros que correspondam a padrões específicos.
