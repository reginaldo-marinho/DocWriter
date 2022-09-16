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
Entre parenteses, são identificadores que alteram o estilo HTML ou que fazem parte da TAG.

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
<h1 color="red;">Introdução ao docwrite<\h1>

```

  P(C=RED,R){Introdução ao projeto DocWriter}
```
P: Indicador que contém a representação HTML

 P => ```<p></p>```

(C=RED,R): Indicador de atributos que contém a representação HTML
  
  C=RED => color:red;
  R => Requerid
  
  P(C=RED,R) => ```<P requerid color="red"></P>```
  
  {Introdução ao projeto DocWriter}: indica o conteúdo da tag

  P(C=RED,R){Introdução ao projeto DocWriter} =>  ```<P requerid color="red">Introdução ao projeto DocWriter</P>```

Na Maioria dos casos o atributo mais utilizado será o 'class'

```
  // Entrada
  P(N,I,S){Interpretando meu texto}
```
```
  // Saida
  <p class = "N I S">Interpretando meu texto</p>
```
```
 /*CSS de Apoio*/
 .N{
     font-weight: bold;
 }
 .I{
     font-style: italic;
 }
 .S{
     text-decoration: overline;
 }
```
