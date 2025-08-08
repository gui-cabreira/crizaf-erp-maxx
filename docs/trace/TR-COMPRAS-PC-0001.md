### Trace – Compras: Pedido de Compras → NF

Fonte (legado)
- Código: `legacy/MaxTek/MaxTek.ERP.BLL/MaxTek.ERP.BLL/NotaFiscalNotasFiscais.cs` linhas 1532–1571, 2421–2460, 4042–4050.
- DAO: `legacy/MaxTek/MaxTek.ERP.DAL/MaxTek.ERP.DAL/SQLServerNotaFiscalNotasFiscaisItens.cs` linhas 845–871.

Regras extraídas
- NF item deve persistir `CodigoPedidoCompra` e `CodigoPedidoCompraItem` quando origem for PC.
- Texto complementar pode incluir "Pedido: {ClienteRef}/{ItemRef}".
- Ao faturar PC, itens viram status “Enviado”.

Tabelas alvo (Azure SQL)
- Schema `CRIZAFAUX`: `PedidoCompraAux`, `PedidoCompraItemAux`, `CotCompras*`, `Sol_Cotacao*`, `Fornecedores (Entidade_*)`.
- NF: `NF`, `NFItens`, `NFSerie`, `NFFormasPagto`, `NFTextosLegais`.

Testes
- Dado um `PedidoCompra*`, ao gerar NF, verificar gravação de chaves do PC no item e alteração de status do item de PC.


