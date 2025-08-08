/* Orçamentos/Custos: composição básica de custos por produto */
IF OBJECT_ID(N'[CRIZAFAUX].[vw_orc_custo]', N'V') IS NOT NULL
    DROP VIEW [CRIZAFAUX].[vw_orc_custo];
GO

CREATE VIEW [CRIZAFAUX].[vw_orc_custo]
AS
SELECT 
    cp.CodigoProduto,
    cp.CustoPadrao,
    ac.id   AS id_arvore,
    ad.id   AS id_detalhe,
    hpp.id  AS id_hist,
    hpp.Custo
FROM CRIZAFAUX.Custo_Produto cp
LEFT JOIN CRIZAFAUX.CustoArvoreCabecalho ac ON ac.CodigoProduto = cp.CodigoProduto
LEFT JOIN CRIZAFAUX.CustoArvoreDetalhes ad ON ad.id_arvore     = ac.id
LEFT JOIN CRIZAFAUX.Hist_Preco_Processo hpp ON hpp.CodigoProduto = cp.CodigoProduto;
GO


