### Compras – Pedido de Compras (PC)

- Objetivo: preservar cadastro, consulta e integração do Pedido de Compras com Notas Fiscais (itens e referências do cliente).
- Integrações chave:
  - NF itens recebem `cd_pedido_compra` e `cd_pedido_compra_item` e compõem descrição/contrato do cliente.
  - Status do PC e dos itens atualizados quando gerada NF a partir do PC.

Evidências no legado

```1532:1571:legacy/MaxTek/MaxTek.ERP.BLL/MaxTek.ERP.BLL/NotaFiscalNotasFiscais.cs
// PedidoCompraRef carregado e usado para gerar NF a partir do PC
```

```2455:2460:legacy/MaxTek/MaxTek.ERP.BLL/MaxTek.ERP.BLL/NotaFiscalNotasFiscais.cs
// Itens de NF recebem CodigoPedidoCompra e CodigoPedidoCompraItem
```

```845:871:legacy/MaxTek/MaxTek.ERP.DAL/MaxTek.ERP.DAL/SQLServerNotaFiscalNotasFiscaisItens.cs
// DAO: filtros por Pedido de Compra e Item
```

Regras mínimas
- Campos obrigatórios por item de NF: `CodigoPedidoCompra`, `CodigoPedidoCompraItem` (quando origem for PC).
- Texto complementar pode incluir: "Pedido: {CodigoPedidoCompraCliente}/{CodigoPedidoCompraItemCliente}".
- Estados: ao faturar do PC, item muda para “Enviado”.

Dados e NCM
- NCM do produto deve estar consistente (ver specs de Fiscal/NFe) para reflexo correto na NF.

Dicionário de dados (Azure SQL)
- CSVs: `docs/db/dictionary/CRIZAFAUX.PedidoCompraAux.csv`, `CRIZAFAUX.PedidoCompraItemAux.csv`, `CRIZAFAUX.CotCompras*.csv`.


