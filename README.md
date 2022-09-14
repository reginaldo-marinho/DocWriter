# DocWriter


DocWriter é um programa usado para criar documentos HTML

Ele está sendo construido para interpretar uma sintaxe de entrada em formato de função que retorna um documento HTML formatado
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
