# Introdução

DocWriter é um programa usado para criar documentos HTML

Ele interpreta um modelo construído em modelo de função/método, estrutura muito conhecida por desenvolvedores.
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
Diferente doutrad estruturas de interpretador/conversor HTML, o docwrite tem estrutura simples que pode ser integrada em qualquer ambiente.

## Interpretadores de plataformas
Interpretadores de plataformas disponibilizam seu Interpretador para criar modelos que são Interpretados dentro da sua própria plataforma, o que implica em dizer antes de utiliza-lo você precisa estar relacionado a àquela plataforma.

## Interpretador docwrite
O Interpretador docwrite interpreta e cria a estrutura do seu projeto de forma que garanta a sua movimentação a qualquer lugar. Vamos olhar com mais detalhe sua construção e o que podemos fazer a partir da sua criação.

### Estrutura Docwrite
Antes de iniciarmos com a estrutura, vamos imaginar a seguinte situação:

"Após a efetivação de alguns estagiários de uma empresa, foi necessário iniciar mais alguns contratos com novos estagiários, esses mesmo estagiários estão ansiosos para começar começ a trabalhar e devido a grande quantidade de trabalho que está tendo atualmente, o responsável pelos treinamentos iniciais está ocupado com outras tarefas."

O que poderia existir como método paliativo para resolver esse problema?

Poderia existir algum documento PDF, WORD ou qualquer outro que inicie esse novo relacionamento com esses estagiários.

O problema dessa resolução é a falta de centralização de conteúdo, falta de atualização e limitação de usabilidade.


