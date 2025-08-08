/* Estoque: cálculo de disponível e exibição de gestão de lote e NCM */
IF OBJECT_ID(N'[CRIZAFAUX].[vw_estoque_disponivel]', N'V') IS NOT NULL
    DROP VIEW [CRIZAFAUX].[vw_estoque_disponivel];
GO

CREATE VIEW [CRIZAFAUX].[vw_estoque_disponivel]
AS
SELECT 
    e.CodigoProduto,
    e.vl_quantidade_estoque    AS estoque,
    e.vl_quantidade_reservada  AS reservado,
    (e.vl_quantidade_estoque - e.vl_quantidade_reservada) AS disponivel,
    e.ic_gestao_lote,
    cf.NCM
FROM CRIZAFAUX.Estoque_Aux e
LEFT JOIN CRIZAFAUX.Classificacao_Fiscal cf ON cf.Codigo = e.cd_classificacao_fiscal;
GO


