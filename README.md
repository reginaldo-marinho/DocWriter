# Introdução

DocWriter é um programa usado para criar documentos HTML

Ele interpreta um modelo construído em forma de função/método, estrutura muito conhecida por desenvolvedores.
```
A(){
}
```
# Explicando o modelo de função
Em letra(s) maiúscula(s) o primeiro identificador do modelo, ele representa o código que será convertido em HTML. 
```
[A](){
}
```
Entre parenteses, são identificadores que alteram o estilo HTML ou parâmetros que podem fazer parte da TAG.

```
A[()]{
}
```
Por fim, as chaves contém o texto que será apresentado no documento HTML.
```
A()[{
}]
```
Vejamos um exemplo de um título que será convertido.
```
H(C=red){
    Introdução ao docwrite
}
```
```
<h1 color="red;">Introdução ao docwrite<\h1>
```
## Tipos de modelos
No docwrite existem dois tipos de modelos, os de auxílio textual e os de auxílio de interfaces.

Modelos textuais - são os modelos que indicam parágrafos, listas e tabelas.

Modelos auxiliares de interface - dão ao documento criado, mais qualidade na sua características, normalmente esse tipo de modelo não aceita parâmetros, já que, na sua própria parametrização as configurações já está definida.

# Arquitetura de uma Projeto
A condução dos documentos docwrite são feitos baseados na estrutura de um livro.
|Livro|Docwrite|Observação|
|-----|--------|----------|
|Nome |Nome Projeto||
|Sumário|Links do Projeto||
|Visual| Página.CSS||
|Títulos|Pagina.HTML||
|Imagens|Pasta Assets|Essa pasta pode conter Fotos, vídeos e Áudios.|
|Anexos| Pasta Dos|Guarda documentos que podem servir para auxílio do leitor.|

# O construtor docwrite
Diferente de outras estruturas de interpretador/conversor HTML, o docwrite tem estrutura simples que pode ser integrada em qualquer ambiente.

## Interpretadores de plataformas
Interpretadores de plataformas disponibilizam seu interpretador para criar modelos que são Interpretados dentro da sua própria plataforma, o que implica em dizer que antes de utiliza-lo você precisa estar relacionado a àquela plataforma.

## Interpretador docwrite
O Interpretador docwrite interpreta e cria a estrutura do seu projeto de forma que garanta a sua movimentação a qualquer lugar, isso permite a criação de documentos que podem ser disponibilizados em qualquer servidor HTTP, como apache, IIS, entre outros. O Docwrite também permite a criação de documentação particular, isso permite ao usuario a liberdade de criar documentos pessoais.

### Estrutura Docwrite
Antes de iniciarmos com a estrutura, vamos imaginar a seguinte situação:

"Após a efetivação de alguns estagiários na empresa ***Foguete X***, foi necessário recrutar novos estagiarios.  Esses estagiários estão ansiosos para começar seu novo trabalho e infelismente devido a grande quantidade de trabalho que está tendo atualmente na ***Foguete X***, o responsável pelos treinamentos iniciais encontra-se ocupado com outras tarefas."

Como resolver esse problema?

R: Poderia existir algum documento PDF, WORD ou qualquer outro que inicie esse novo relacionamento com esses estagiários.

O problema dessa resolução é a falta de centralização de conteúdo, falta de atualização e limitação de usabilidade.

Agora para resolver esse problema de forma mais elegante, mais produtiva e de forma mais flexível, poderíamos criar um projeto docwrite que direcione inicialmente esse trabalho.

### Criando um Primeiro Projeto 
1 - Ao  especificar o nome do projeto, docwrite irá receber o nome desse projeto, que logo em seguida será convertido em uma pasta, essa pasta é o ponto de entrada principal do projeto, ela pode ser caracterizada como a página de um livro, onde, ao abrir você encontrará todo conteudo que ali se encontra. Para nosso exemplo usaremos o nome **docwrite-introducao**.

![image](https://user-images.githubusercontent.com/60780631/191047536-03756be2-64ef-46f6-9ddb-2248df6d03d7.png)


2 - A partir do projeto criado, podemos adicionar varias "Paginas" que representam um titulo especifico do projeto, isso segrega tudo conteudo que faz parte da pagina em uma única pasta. A pasta criada contem o mesmo nome da pagina espeficada, para nosso exemplo utilizaremos uma pagina chamada  **introducao**. 

![image](https://user-images.githubusercontent.com/60780631/191048746-6bdb3f86-7a14-475a-93fe-5d6d4802b79e.png)

Dentro dessa pasta/pagina, encontraremos uma estrutura organizada de arquivos e pastas.

![image](https://user-images.githubusercontent.com/60780631/191048899-7956e96d-3eb2-4baf-9d7b-82309c11d8e1.png)

Poderiamos criar outras páginas, vamos criar mais uma chamada **sintaxe-modelo**, observe que ela seguirá a mesma estrura.

![image](https://user-images.githubusercontent.com/60780631/191049685-ada8229c-551a-428d-b46f-4bc096da7489.png)

![image](https://user-images.githubusercontent.com/60780631/191049735-84616a8b-e5dd-4082-8546-0b5ad0473fab.png)


Em resumo, e estrutura atual do projeto estaria desse modo:

![image](https://user-images.githubusercontent.com/60780631/191051578-fd854f3b-9e13-4067-985c-a9d62b0810a4.png)

