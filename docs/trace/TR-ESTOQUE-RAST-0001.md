### Trace – Estoque: Disponível e Lote

Fonte (legado)
- `SqlCriarBaseDados.cs` 1142–1163: coluna calculada `vl_quantidade_disponivel = vl_quantidade_estoque - vl_quantidade_reservada`.
- `TecnicoEngenharia.Produto`: flags e valores de lote (`ic_gestao_lote`, `vl_lote_economico`).

Tabelas alvo (Azure SQL)
- `CRIZAFAUX.Estoque_*`, `CRIZAFAUX.Classificacao_Fiscal`, `CRIZAFAUX.Estoque_Consignado`, `CRIZAFAUX.ContadorLotes`.

Regras
- Quando `ic_gestao_lote = 1`, movimentações por lote são obrigatórias e devem refletir no disponível.

Testes
- Inserir movimentações de reserva e verificar atualização da coluna calculada de disponível.


