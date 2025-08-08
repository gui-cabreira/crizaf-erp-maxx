### Trace – Engenharia: Processo/Operações/Ferramentas/Revisões

Fonte (legado)
- `ModuloTecnicoEngenhariaProcesso.cs` (CRUD completo – linhas 148–249 e adjacências).
- `TecnicoEngenhariaProcessoOperacao.cs` 1334–1376 (carga de ferramentas e revisões; incremento de revisão).

Tabelas alvo (Azure SQL)
- `CRIZAFAUX.ProcessoControleCom`, `CRIZAFAUX.ProcessoCtrlFerram`, `CRIZAFAUX.ProcessoTarifa` e correlatas.

Regras
- Ao salvar alteração relevante em operação, incrementar `RevisaoOperacao` e registrar histórico.

Testes
- Inserir nova ferramenta em operação e validar incremento de revisão e persistência da relação.


