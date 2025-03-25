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

#Select Avançado
## 1. SQL Select Distinct

**Objetivo:**  
Retornar somente valores únicos (sem duplicatas) de uma coluna.

**Exemplo:**  
Imagine que você queira listar os endereços dos alunos sem repetições:

```sql
SELECT DISTINCT endereco
FROM alunos;
```

**Explicação:**  
O comando `DISTINCT` elimina registros duplicados. Se houver vários alunos com o mesmo endereço, o resultado mostrará cada endereço apenas uma vez.

---

## 2. SQL Select Top

**Objetivo:**  
Retornar um número específico de registros do resultado.

**Exemplo:**  
Para listar os 5 primeiros alunos cadastrados:

```sql
SELECT TOP 5 *
FROM alunos;
```

**Explicação:**  
O comando `TOP` limita a quantidade de linhas retornadas. Isso é útil quando queremos amostrar os dados ou quando há necessidade de otimização na consulta.

---

## 3. SQL Aliases

**Objetivo:**  
Renomear colunas ou tabelas temporariamente na consulta para melhorar a legibilidade.

**Exemplo:**  
Para exibir o nome dos alunos com um título mais amigável:

```sql
SELECT nome AS [Nome do Aluno], idade AS [Idade do Aluno]
FROM alunos;
```

**Explicação:**  
O `AS` cria um alias (apelido) para a coluna ou tabela. Aqui, `nome` será exibido como “Nome do Aluno” e `idade` como “Idade do Aluno” no resultado.

---

## 4. SQL Where

**Objetivo:**  
Filtrar registros de acordo com condições específicas.

**Exemplo:**  
Para selecionar alunos com idade superior a 18 anos:

```sql
SELECT *
FROM alunos
WHERE idade > 18;
```

**Explicação:**  
A cláusula `WHERE` restringe os registros retornados conforme a condição definida.

---

## 5. SQL And

**Objetivo:**  
Combinar múltiplas condições onde todas devem ser verdadeiras.

**Exemplo:**  
Para selecionar alunos com idade acima de 18 e que residam em "São Paulo":

```sql
SELECT *
FROM alunos
WHERE idade > 18 AND endereco = 'São Paulo';
```

**Explicação:**  
O operador `AND` garante que ambas as condições (idade e endereço) sejam satisfeitas para que o registro seja incluído no resultado.

---

## 6. SQL Or

**Objetivo:**  
Combinar condições onde pelo menos uma deve ser verdadeira.

**Exemplo:**  
Para selecionar alunos que sejam maiores de 18 anos ou que morem em "Rio de Janeiro":

```sql
SELECT *
FROM alunos
WHERE idade > 18 OR endereco = 'Rio de Janeiro';
```

**Explicação:**  
O operador `OR` retorna os registros que satisfazem pelo menos uma das condições informadas.

---

## 7. SQL Not

**Objetivo:**  
Negar uma condição, retornando os registros que não satisfazem a condição.

**Exemplo:**  
Para selecionar alunos que **não** morem em "Belo Horizonte":

```sql
SELECT *
FROM alunos
WHERE NOT endereco = 'Belo Horizonte';
```

**Explicação:**  
O `NOT` inverte o critério, ou seja, seleciona os registros que não correspondem à condição especificada.

---

## 8. SQL Between

**Objetivo:**  
Selecionar registros dentro de um intervalo especificado.

**Exemplo:**  
Para selecionar alunos com idade entre 15 e 20 anos (inclusive):

```sql
SELECT *
FROM alunos
WHERE idade BETWEEN 15 AND 20;
```

**Explicação:**  
O operador `BETWEEN` define um intervalo, incluindo os valores extremos (15 e 20 neste exemplo).

---

## 9. SQL In

**Objetivo:**  
Selecionar registros que possuem um valor dentro de um conjunto especificado.

**Exemplo:**  
Para selecionar alunos que morem em "São Paulo", "Rio de Janeiro" ou "Curitiba":

```sql
SELECT *
FROM alunos
WHERE endereco IN ('São Paulo', 'Rio de Janeiro', 'Curitiba');
```

**Explicação:**  
O operador `IN` permite especificar múltiplos valores para comparação na cláusula `WHERE`, simplificando a consulta em vez de usar vários `OR`.

---

## 10. SQL Order By

**Objetivo:**  
Ordenar os registros resultantes de uma consulta.

**Exemplo:**  
Para ordenar os alunos por nome em ordem alfabética:

```sql
SELECT *
FROM alunos
ORDER BY nome ASC;
```

**Explicação:**  
A cláusula `ORDER BY` organiza os registros com base na coluna especificada. O modificador `ASC` (ascendente) é opcional, pois essa é a ordem padrão; pode-se usar `DESC` para ordem decrescente.

---

## 11. SQL Null Values

**Objetivo:**  
Tratar valores nulos (NULL) nas consultas.

**Exemplo 1 – Selecionar registros onde o telefone não foi informado:**

```sql
SELECT *
FROM alunos
WHERE telefone IS NULL;
```

**Exemplo 2 – Selecionar registros onde o telefone foi informado:**

```sql
SELECT *
FROM alunos
WHERE telefone IS NOT NULL;
```

**Explicação:**  
No SQL, `NULL` representa a ausência de valor. Para comparar com `NULL`, deve-se usar `IS NULL` ou `IS NOT NULL` em vez de operadores de comparação tradicionais.

---
Dando continuidade ao material didático, vamos abordar os próximos comandos SQL utilizando a tabela **alunos**.

---

## 12. SQL Group By

**Objetivo:**  
Agrupar registros que possuem valores iguais em uma ou mais colunas, geralmente para aplicar funções de agregação.

**Exemplo:**  
Para contar quantos alunos existem em cada endereço:

```sql
SELECT endereco, COUNT(*) AS TotalAlunos
FROM alunos
GROUP BY endereco;
```

**Explicação:**  
A cláusula `GROUP BY` agrupa os registros pelo valor da coluna `endereco`. Em seguida, a função agregada `COUNT(*)` conta quantos alunos estão associados a cada endereço, retornando um resultado resumido.

---

## 13. SQL Having

**Objetivo:**  
Filtrar os resultados de grupos formados pela cláusula `GROUP BY`, aplicando condições aos resultados agregados.

**Exemplo:**  
Para mostrar somente os endereços onde existem mais de 1 aluno:

```sql
SELECT endereco, COUNT(*) AS TotalAlunos
FROM alunos
GROUP BY endereco
HAVING COUNT(*) > 1;
```

**Explicação:**  
A cláusula `HAVING` atua sobre os grupos criados pelo `GROUP BY`. Nesse exemplo, ela filtra e retorna somente os grupos com mais de um aluno, ou seja, onde o `COUNT(*)` é maior que 1.

---

## 14. SQL Aggregate Functions

**Objetivo:**  
Executar cálculos sobre um conjunto de valores para retornar um único valor. As funções agregadas comuns incluem `COUNT`, `SUM`, `AVG`, `MIN` e `MAX`.

**Explicação:**  
Essas funções são amplamente utilizadas para gerar estatísticas e resumos dos dados. Nos exemplos seguintes, veremos como aplicar cada uma delas.

---

## 15. SQL Min and Max

**Objetivo:**  
Encontrar os valores mínimo e máximo de uma coluna numérica.

**Exemplo:**  
Para identificar a menor e a maior idade dos alunos:

```sql
SELECT MIN(idade) AS MenorIdade, MAX(idade) AS MaiorIdade
FROM alunos;
```

**Explicação:**  
A função `MIN(idade)` retorna a menor idade registrada, enquanto `MAX(idade)` retorna a maior idade. Os aliases `MenorIdade` e `MaiorIdade` facilitam a leitura dos resultados.

---

## 16. SQL Count

**Objetivo:**  
Contar o número de registros em um conjunto de resultados.

**Exemplo:**  
Para contar quantos alunos estão cadastrados na tabela:

```sql
SELECT COUNT(*) AS TotalAlunos
FROM alunos;
```

**Explicação:**  
A função `COUNT(*)` conta todas as linhas da tabela `alunos`. O resultado é apresentado com o alias `TotalAlunos`.

---

## 17. SQL Sum

**Objetivo:**  
Somar os valores de uma coluna numérica.

**Exemplo:**  
Para somar as idades dos alunos (por exemplo, para obter um total que pode ser útil em alguns cálculos):

```sql
SELECT SUM(idade) AS SomaDasIdades
FROM alunos;
```

**Explicação:**  
A função `SUM(idade)` calcula a soma de todas as idades presentes na tabela. Essa soma é rotulada com o alias `SomaDasIdades`.

---

## 18. SQL Avg

**Objetivo:**  
Calcular a média dos valores de uma coluna numérica.

**Exemplo:**  
Para determinar a média de idade dos alunos:

```sql
SELECT AVG(idade) AS MediaDeIdade
FROM alunos;
```

**Explicação:**  
A função `AVG(idade)` calcula a média das idades de todos os alunos cadastrados. O alias `MediaDeIdade` é usado para nomear o resultado, facilitando a interpretação dos dados.

---
Segue abaixo uma explicação detalhada sobre *joins* e *union* com exemplos práticos utilizando duas tabelas: **alunos** e **matriculas**. Para facilitar, considere as seguintes definições:

- **Tabela alunos**:  
  Colunas:  
  - `nome`  
  - `idade`  
  - `endereco`  
  - `telefone`

- **Tabela matriculas**:  
  Colunas:  
  - `nome` (representando o nome do aluno, chave para relacionamento com a tabela alunos)  
  - `curso`  
  - `data_matricula`

> **Observação:** Na prática, recomenda-se usar chaves primárias e estrangeiras (por exemplo, um `id_aluno`) para relacionar as tabelas, mas, para simplicidade, usaremos a coluna `nome` como referência comum.

---
# Relacionamento entre tabelas SQL

## 1. Criação das Tabelas e Inserts

- **Professores:**  
  - *Pedro* (id 1)  
  - *Tales Augusto* (id 2)

- **Matérias:**  
  - *HTML* (id 1, lecionada pelo professor Pedro)  
  - *SQL* (id 2, lecionada pelo professor Pedro)  
  - *Lógica de Programação* (id 3, lecionada pelo professor Tales Augusto)

- **Alunos:**  
  Exemplo com alguns registros de alunos.

- **Matrículas:**  
  Relação entre aluno e matéria (através dos ids) que, por sua vez, permite associar o professor responsável via a matéria.

---


### a) Tabela Professores

```sql
CREATE TABLE Professores (
  id INT PRIMARY KEY,
  nome VARCHAR(100)
);

INSERT INTO Professores (id, nome) VALUES 
(1, 'Pedro'),
(2, 'Tales Augusto');
```

### b) Tabela Matérias

```sql
CREATE TABLE Materias (
  id INT PRIMARY KEY,
  nome VARCHAR(100),
  professor_id INT,
  FOREIGN KEY (professor_id) REFERENCES Professores(id)
);

INSERT INTO Materias (id, nome, professor_id) VALUES 
(1, 'HTML', 1),
(2, 'SQL', 1),
(3, 'Lógica de Programação', 2);
```

### c) Tabela Alunos

```sql
CREATE TABLE Alunos (
  id INT PRIMARY KEY,
  nome VARCHAR(100),
  idade INT,
  endereco VARCHAR(200),
  telefone VARCHAR(20)
);

INSERT INTO Alunos (id, nome, idade, endereco, telefone) VALUES 
(1, 'João Silva', 20, 'Rua A, 123', '1111-1111'),
(2, 'Maria Souza', 22, 'Rua B, 456', '2222-2222'),
(3, 'Carlos Pereira', 19, 'Rua C, 789', '3333-3333');
```

### d) Tabela Matrículas (Relação entre aluno e matéria)

```sql
CREATE TABLE Matriculas (
  aluno_id INT,
  materia_id INT,
  FOREIGN KEY (aluno_id) REFERENCES Alunos(id),
  FOREIGN KEY (materia_id) REFERENCES Materias(id)
);

INSERT INTO Matriculas (aluno_id, materia_id) VALUES 
(1, 1),  -- João Silva se matricula em HTML
(1, 2),  -- João Silva se matricula em SQL
(2, 3),  -- Maria Souza se matricula em Lógica de Programação
(3, 2);  -- Carlos Pereira se matricula em SQL
```

---

## 2. Exemplos Detalhados de SQL Joins e Union

### SQL Joins (Conceito Geral)

*Joins* são usados para combinar registros de duas ou mais tabelas com base em uma condição de relacionamento. Nesse exemplo, relacionaremos os alunos com as matérias que cursam e os respectivos professores que lecionam cada matéria.

![Tipos de Join](https://raw.githubusercontent.com/pedro381/tutorial-crud/refs/heads/main/tipos-de-join-2-jpg.webp)


---

### a) SQL Inner Join

**Objetivo:**  
Retornar somente os registros que possuem correspondência em todas as tabelas envolvidas.

**Exemplo:**

```sql
SELECT 
  a.nome AS Aluno, 
  m.nome AS Materia, 
  p.nome AS Professor
FROM Alunos a
INNER JOIN Matriculas ma ON a.id = ma.aluno_id
INNER JOIN Materias m ON ma.materia_id = m.id
INNER JOIN Professores p ON m.professor_id = p.id;
```

**Explicação:**  
- Cada `INNER JOIN` garante que somente os registros com correspondência em ambas as tabelas sejam retornados.  
- Se um aluno estiver matriculado em uma matéria e essa matéria tiver um professor associado, o registro aparecerá.  
- No exemplo, João Silva aparece duas vezes (por cursar HTML e SQL), enquanto Maria Souza e Carlos Pereira aparecem conforme suas respectivas matrículas.

---

### b) SQL Left Join

**Objetivo:**  
Retornar todos os registros da tabela à esquerda (neste caso, **Alunos**), mesmo que não haja correspondência nas tabelas à direita. Os campos das tabelas à direita serão exibidos como `NULL` se não houver correspondência.

**Exemplo:**

```sql
SELECT 
  a.nome AS Aluno, 
  m.nome AS Materia, 
  p.nome AS Professor
FROM Alunos a
LEFT JOIN Matriculas ma ON a.id = ma.aluno_id
LEFT JOIN Materias m ON ma.materia_id = m.id
LEFT JOIN Professores p ON m.professor_id = p.id;
```

**Explicação:**  
- Essa consulta lista todos os alunos cadastrados.  
- Se um aluno não tiver matrícula, as colunas `Materia` e `Professor` serão `NULL`.  
- Útil para identificar alunos que ainda não se matricularam em nenhuma matéria.

---

### c) SQL Right Join

**Objetivo:**  
Retornar todos os registros da tabela à direita (neste caso, **Matriculas**), mesmo que não haja correspondência na tabela à esquerda (**Alunos**).

**Exemplo:**

```sql
SELECT 
  a.nome AS Aluno, 
  m.nome AS Materia, 
  p.nome AS Professor
FROM Matriculas ma
RIGHT JOIN Alunos a ON a.id = ma.aluno_id
INNER JOIN Materias m ON ma.materia_id = m.id
INNER JOIN Professores p ON m.professor_id = p.id;
```

**Explicação:**  
- Embora o `RIGHT JOIN` esteja sendo usado para garantir que todos os registros de **Alunos** sejam exibidos, é importante notar que, se houver registros de matrícula sem aluno correspondente (o que não deve ocorrer com integridade referencial), os dados do aluno seriam `NULL`.  
- Aqui, combinamos o `RIGHT JOIN` com os `INNER JOIN` seguintes para garantir a ligação com as matérias e professores.

*Observação:* Em cenários práticos, o uso do `RIGHT JOIN` é menos comum, pois a mesma lógica pode ser alcançada com um `LEFT JOIN` invertendo a ordem das tabelas.

---

### d) SQL Full Join

**Objetivo:**  
Retornar todos os registros de ambas as tabelas, preenchendo com `NULL` onde não houver correspondência.

**Exemplo:**

```sql
SELECT 
  a.nome AS Aluno, 
  m.nome AS Materia, 
  p.nome AS Professor
FROM Alunos a
FULL JOIN Matriculas ma ON a.id = ma.aluno_id
FULL JOIN Materias m ON ma.materia_id = m.id
FULL JOIN Professores p ON m.professor_id = p.id;
```

**Explicação:**  
- O `FULL JOIN` combina os efeitos do `LEFT JOIN` e do `RIGHT JOIN`.  
- Todos os alunos, matrículas, matérias e professores serão listados.  
- Se um registro não tiver correspondência em uma das tabelas, os campos dessa tabela serão `NULL`.  
- Esse tipo de join é útil para análises que exigem uma visão completa dos dados, mesmo quando há inconsistências ou faltam relacionamentos.

---

### e) SQL Union

**Objetivo:**  
Unir os resultados de duas consultas SELECT que retornam o mesmo número e tipo de colunas. O `UNION` elimina registros duplicados; se desejar manter duplicatas, utilize `UNION ALL`.

**Exemplo:**

Imagine que você deseja obter uma lista única de nomes que aparecem tanto na tabela de alunos quanto na tabela de professores:

```sql
SELECT nome FROM Alunos
UNION
SELECT nome FROM Professores;
```

**Explicação:**  
- Ambas as consultas retornam uma coluna (`nome`), que deve ter tipos compatíveis.  
- O `UNION` combina os resultados, removendo registros duplicados.  
- Se um mesmo nome existir nas duas tabelas, ele aparecerá apenas uma vez no resultado final.  
- Esse comando é útil para consolidar informações vindas de tabelas diferentes em uma única lista.

---

## Considerações Finais

- **Escolha do Join:**  
  - Use o **INNER JOIN** quando quiser registros que existam em todas as tabelas relacionadas.  
  - Use o **LEFT JOIN** para garantir que todos os registros da tabela à esquerda sejam exibidos, mesmo sem correspondência.  
  - O **RIGHT JOIN** faz o oposto, porém é menos utilizado.  
  - O **FULL JOIN** é indicado para obter uma visão completa dos dados, mostrando todas as combinações, mesmo que não haja correspondência.

- **Uso do UNION:**  
  - Combine dados de diferentes fontes quando as colunas forem compatíveis.  
  - Lembre-se que o `UNION` elimina duplicatas automaticamente; utilize `UNION ALL` se desejar manter todas as ocorrências.


