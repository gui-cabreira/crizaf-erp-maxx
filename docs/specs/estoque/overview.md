### Estoque – Consulta e Rastreabilidade

- Objetivo: preservar saldos por produto/lote e rastreabilidade (Kardex), com cálculo de disponível.

Evidências no legado

```1142:1163:legacy/MaxTek/MaxTek.ERP.DAL/MaxTek.ERP.DAL/SqlCriarBaseDados.cs
[vl_quantidade_disponivel]  AS ([vl_quantidade_estoque]-[vl_quantidade_reservada])
```

```2149:2214:legacy/MaxTek/MaxTek.ERP.DAL/MaxTek.ERP.DAL/SqlCriarBaseDados.cs
// DF_Produto_ic_gestao_lote e DF_Produto_vl_lote_economico
```

Regras mínimas
- Exibir `estoque`, `reservado`, `disponível`.
- Quando `ic_gestao_lote = 1`, operações por lote são obrigatórias.
- NF armazena `cd_lote` quando aplicável.

Dicionário de dados (Azure SQL)
- CSVs: `docs/db/dictionary/CRIZAFAUX.Estoque_Aux.csv`, `CRIZAFAUX.Classificacao_Fiscal.csv`, `CRIZAFAUX.ContadorLotes.csv`, `CRIZAFAUX.Estoque_Consignado.csv`.


