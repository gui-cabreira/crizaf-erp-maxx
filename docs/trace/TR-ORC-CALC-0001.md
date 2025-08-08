### Trace – Orçamentos/Cálculo Rápido: Formação de Preço

Fonte (legado)
- `SqlCriarBaseDados.cs` (campos de preço no produto e catálogo de preços de vendas).
- Custos por processo e históricos: `Hist_Preco_Processo`, `Custo_*`.

Tabelas alvo (Azure SQL)
- `CRIZAFAUX.Custo_Produto`, `CRIZAFAUX.CustoArvore*`, `CRIZAFAUX.Hist_Preco_Processo`, `CRIZAFAUX.VendasCatalogosCodigos`.

Regras
- Cálculo por lote com breakdown: Setup, Produção, Terceiros, Matéria, Componentes, %Imposto, Markup, preço unitário e total.

Testes
- Calcular para lote 1 e lote N e validar variação de custo unitário conforme rateios previstos.


