# Introdução

DocWriter é um programa usado para criar documentos HTML

Ele interpreta um modelo construído em modelo de função/método, estrutura muito conhecida por desenvolvedores.
```
A(){
}
```
## Explicando o modelo de função
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
### Tipos de modelos
No docwrite existem dois tipos de modelos, os de auxílio textual e os de auxílio de interfaces.

Modelos textuais - são os modelos que indicam parágrafos, listas e tabelas.

Modelos auxiliares de interface - dão ao documento criado, mais qualidade na sua características, normalmente esse tipo de modelo não aceita parâmetros, já que, na sua própria parametrização as configurações já está definida.

## Construção
A condução dos documentos docwrite são feitos baseados na estrutura de um livro.
|Livro|Docwrite|Observação|
|-----|--------|----------|
|Nome |Nome Projeto||
|Sumário|Links do Projeto||
|Visual| Página.CSS||
|Títulos|Pagina.HTML||
|Imagens|Pasta Assets|Essa pasta pode conter Fotos, vídeos e Áudios.|
|Anexos| Pasta Dos|Guarda documentos que podem servir para auxílio do leitor.|

