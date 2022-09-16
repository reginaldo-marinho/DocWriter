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
```
<h1 color="red;">Introdução ao docwrite<\h1>
```

