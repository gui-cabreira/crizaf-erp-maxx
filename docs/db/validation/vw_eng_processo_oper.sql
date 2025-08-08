/* Engenharia: controle de processos, ferramentas e tarifas */
IF OBJECT_ID(N'[CRIZAFAUX].[vw_eng_processo_oper]', N'V') IS NOT NULL
    DROP VIEW [CRIZAFAUX].[vw_eng_processo_oper];
GO

CREATE VIEW [CRIZAFAUX].[vw_eng_processo_oper]
AS
SELECT 
    c.id               AS id_controle,
    f.id               AS id_ferramenta,
    t.id               AS id_tarifa
FROM CRIZAFAUX.ProcessoControleCom c
LEFT JOIN CRIZAFAUX.ProcessoCtrlFerram f ON f.id_controle = c.id
LEFT JOIN CRIZAFAUX.ProcessoTarifa     t ON t.id_controle = c.id;
GO


