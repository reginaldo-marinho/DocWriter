# Introdução

DocWriter é um programa usado para criar documentos HTML

Ele interpreta um modelo construído em modelo de função/método, estrutura muito conhecida por desenvolvedores.
A(){
}
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
