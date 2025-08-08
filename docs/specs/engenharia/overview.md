### Engenharia – Estrutura de Produto e Processos

- Objetivo: manter estrutura (BOM) e processos com operações, ferramentas e revisões.

Evidências no legado

```148:199:legacy/MaxTek/MaxTek.ERP.BLL/MaxTek.ERP.BLL/ModuloTecnicoEngenhariaProcesso.cs
// CRUD de ProcessoOperacao / OperacaoFerramenta / OperacaoRevisao
```

```1334:1376:legacy/MaxTek/MaxTek.ERP.BLL/MaxTek.ERP.BLL/TecnicoEngenhariaProcessoOperacao.cs
// Navegação: Ferramentas e Revisões por Operação
```

Regras mínimas
- Revisão de operação incrementa `RevisaoOperacao` automaticamente ao salvar novas alterações.
- Integração com Produção/Apontamentos para custos e tempos.

Dicionário de dados (Azure SQL)
- CSVs: `docs/db/dictionary/CRIZAFAUX.ProcessoControleCom.csv`, `CRIZAFAUX.ProcessoCtrlFerram.csv`, `CRIZAFAUX.ProcessoTarifa.csv`.


