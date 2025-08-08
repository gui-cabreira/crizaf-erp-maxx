### Orçamentos e Cálculo Rápido

- Objetivo: calcular preço com os mesmos componentes (Setup, Produção, Terceiros, Matéria, Componentes, Lote, %Imposto) usando custos do produto e parâmetros do processo.

Evidências no legado

```2226:2277:legacy/MaxTek/MaxTek.ERP.DAL/MaxTek.ERP.DAL/SqlCriarBaseDados.cs
// Campos de preço no produto (base, última, média – compra/venda)
```

```466:1710:legacy/MaxTek/MaxTek.ERP.DAL/MaxTek.ERP.DAL/SqlCriarBaseDados.cs
// Catálogo de preços de vendas (Comercial.VendasCatalogosCodigos)
```

Regras mínimas
- Definir lote para cálculo; refletir impacto em custo unitário.
- Exibir breakdown por componente de custo e preço final.

Dicionário de dados (Azure SQL)
- CSVs: `docs/db/dictionary/CRIZAFAUX.Custo_Produto.csv`, `CRIZAFAUX.CustoArvoreCabecalho.csv`, `CRIZAFAUX.CustoArvoreDetalhes.csv`, `CRIZAFAUX.Hist_Preco_Processo.csv`, `CRIZAFAUX.CatalogoCodigos.csv`, `CRIZAFAUX.VendasPagamentos.csv`.


