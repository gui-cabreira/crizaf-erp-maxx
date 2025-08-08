/* Compras → NF: vínculo de Pedido de Compras nos itens da NF */
IF OBJECT_ID(N'[CRIZAFAUX].[vw_nf_pc]', N'V') IS NOT NULL
    DROP VIEW [CRIZAFAUX].[vw_nf_pc];
GO

CREATE VIEW [CRIZAFAUX].[vw_nf_pc]
AS
SELECT 
    i.cd_pedido_compra,
    i.cd_pedido_compra_item,
    i.nm_pedido_compra_cliente,
    i.cd_pedido_compra_item_cliente,
    i.cd_nota_fiscal,
    i.cd_serie_nf,
    n.dt_emissao,
    pA.No_cmde            AS pedido_compra_numero,
    pI.Codigo             AS pedido_compra_item_codigo
FROM CRIZAFAUX.NFItens i
INNER JOIN CRIZAFAUX.NF n
    ON n.cd_nota_fiscal = i.cd_nota_fiscal
   AND n.cd_serie_nota_fiscal = i.cd_serie_nf
LEFT  JOIN CRIZAFAUX.PedidoCompraAux       pA ON pA.No_cmde = i.cd_pedido_compra
LEFT  JOIN CRIZAFAUX.PedidoCompraItemAux   pI ON pI.Codigo  = i.cd_pedido_compra_item;
GO


