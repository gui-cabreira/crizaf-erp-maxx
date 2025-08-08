using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Office;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Commands;
using DevExpress.XtraBars.Commands.Ribbon;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Design;
using DevExpress.XtraRichEdit.Forms.Design;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraRichEdit.UI;

namespace MaxTek.Core.Windows.UserControls;

public class ucWord : XtraUserControl
{
	private IContainer components = null;

	private RichEditControl rcDocumento;

	private RibbonControl ribbonControl1;

	private ChangeSectionPageMarginsItem changeSectionPageMarginsItem1;

	private SetNormalSectionPageMarginsItem setNormalSectionPageMarginsItem1;

	private SetNarrowSectionPageMarginsItem setNarrowSectionPageMarginsItem1;

	private SetModerateSectionPageMarginsItem setModerateSectionPageMarginsItem1;

	private SetWideSectionPageMarginsItem setWideSectionPageMarginsItem1;

	private ShowPageMarginsSetupFormItem showPageMarginsSetupFormItem1;

	private ChangeSectionPageOrientationItem changeSectionPageOrientationItem1;

	private SetPortraitPageOrientationItem setPortraitPageOrientationItem1;

	private SetLandscapePageOrientationItem setLandscapePageOrientationItem1;

	private ChangeSectionPaperKindItem changeSectionPaperKindItem1;

	private ChangeSectionColumnsItem changeSectionColumnsItem1;

	private SetSectionOneColumnItem setSectionOneColumnItem1;

	private SetSectionTwoColumnsItem setSectionTwoColumnsItem1;

	private SetSectionThreeColumnsItem setSectionThreeColumnsItem1;

	private ShowColumnsSetupFormItem showColumnsSetupFormItem1;

	private InsertBreakItem insertBreakItem1;

	private InsertPageBreakItem insertPageBreakItem1;

	private InsertColumnBreakItem insertColumnBreakItem1;

	private InsertSectionBreakNextPageItem insertSectionBreakNextPageItem1;

	private InsertSectionBreakEvenPageItem insertSectionBreakEvenPageItem1;

	private InsertSectionBreakOddPageItem insertSectionBreakOddPageItem1;

	private ChangeSectionLineNumberingItem changeSectionLineNumberingItem1;

	private SetSectionLineNumberingNoneItem setSectionLineNumberingNoneItem1;

	private SetSectionLineNumberingContinuousItem setSectionLineNumberingContinuousItem1;

	private SetSectionLineNumberingRestartNewPageItem setSectionLineNumberingRestartNewPageItem1;

	private SetSectionLineNumberingRestartNewSectionItem setSectionLineNumberingRestartNewSectionItem1;

	private ToggleParagraphSuppressLineNumbersItem toggleParagraphSuppressLineNumbersItem1;

	private ShowLineNumberingFormItem showLineNumberingFormItem1;

	private ChangePageColorItem changePageColorItem1;

	private SwitchToSimpleViewItem switchToSimpleViewItem1;

	private SwitchToDraftViewItem switchToDraftViewItem1;

	private SwitchToPrintLayoutViewItem switchToPrintLayoutViewItem1;

	private ToggleShowHorizontalRulerItem toggleShowHorizontalRulerItem1;

	private ToggleShowVerticalRulerItem toggleShowVerticalRulerItem1;

	private ZoomOutItem zoomOutItem1;

	private ZoomInItem zoomInItem1;

	private GoToPageHeaderItem goToPageHeaderItem1;

	private GoToPageFooterItem goToPageFooterItem1;

	private GoToNextHeaderFooterItem goToNextHeaderFooterItem1;

	private GoToPreviousHeaderFooterItem goToPreviousHeaderFooterItem1;

	private ToggleLinkToPreviousItem toggleLinkToPreviousItem1;

	private ToggleDifferentFirstPageItem toggleDifferentFirstPageItem1;

	private ToggleDifferentOddAndEvenPagesItem toggleDifferentOddAndEvenPagesItem1;

	private ClosePageHeaderFooterItem closePageHeaderFooterItem1;

	private ToggleFirstRowItem toggleFirstRowItem1;

	private ToggleLastRowItem toggleLastRowItem1;

	private ToggleBandedRowsItem toggleBandedRowsItem1;

	private ToggleFirstColumnItem toggleFirstColumnItem1;

	private ToggleLastColumnItem toggleLastColumnItem1;

	private ToggleBandedColumnsItem toggleBandedColumnsItem1;

	private GalleryChangeTableStyleItem galleryChangeTableStyleItem1;

	private ChangeTableBorderLineStyleItem changeTableBorderLineStyleItem1;

	private RepositoryItemBorderLineStyle repositoryItemBorderLineStyle1;

	private ChangeTableBorderLineWeightItem changeTableBorderLineWeightItem1;

	private RepositoryItemBorderLineWeight repositoryItemBorderLineWeight1;

	private ChangeTableBorderColorItem changeTableBorderColorItem1;

	private ChangeTableBordersItem changeTableBordersItem1;

	private ToggleTableCellsBottomBorderItem toggleTableCellsBottomBorderItem1;

	private ToggleTableCellsTopBorderItem toggleTableCellsTopBorderItem1;

	private ToggleTableCellsLeftBorderItem toggleTableCellsLeftBorderItem1;

	private ToggleTableCellsRightBorderItem toggleTableCellsRightBorderItem1;

	private ResetTableCellsAllBordersItem resetTableCellsAllBordersItem1;

	private ToggleTableCellsAllBordersItem toggleTableCellsAllBordersItem1;

	private ToggleTableCellsOutsideBorderItem toggleTableCellsOutsideBorderItem1;

	private ToggleTableCellsInsideBorderItem toggleTableCellsInsideBorderItem1;

	private ToggleTableCellsInsideHorizontalBorderItem toggleTableCellsInsideHorizontalBorderItem1;

	private ToggleTableCellsInsideVerticalBorderItem toggleTableCellsInsideVerticalBorderItem1;

	private ToggleShowTableGridLinesItem toggleShowTableGridLinesItem1;

	private ChangeTableCellsShadingItem changeTableCellsShadingItem1;

	private SelectTableElementsItem selectTableElementsItem1;

	private SelectTableCellItem selectTableCellItem1;

	private SelectTableColumnItem selectTableColumnItem1;

	private SelectTableRowItem selectTableRowItem1;

	private SelectTableItem selectTableItem1;

	private ShowTablePropertiesFormItem showTablePropertiesFormItem1;

	private DeleteTableElementsItem deleteTableElementsItem1;

	private ShowDeleteTableCellsFormItem showDeleteTableCellsFormItem1;

	private DeleteTableColumnsItem deleteTableColumnsItem1;

	private DeleteTableRowsItem deleteTableRowsItem1;

	private DeleteTableItem deleteTableItem1;

	private InsertTableRowAboveItem insertTableRowAboveItem1;

	private InsertTableRowBelowItem insertTableRowBelowItem1;

	private InsertTableColumnToLeftItem insertTableColumnToLeftItem1;

	private InsertTableColumnToRightItem insertTableColumnToRightItem1;

	private MergeTableCellsItem mergeTableCellsItem1;

	private ShowSplitTableCellsForm showSplitTableCellsForm1;

	private SplitTableItem splitTableItem1;

	private ToggleTableAutoFitItem toggleTableAutoFitItem1;

	private ToggleTableAutoFitContentsItem toggleTableAutoFitContentsItem1;

	private ToggleTableAutoFitWindowItem toggleTableAutoFitWindowItem1;

	private ToggleTableFixedColumnWidthItem toggleTableFixedColumnWidthItem1;

	private ToggleTableCellsTopLeftAlignmentItem toggleTableCellsTopLeftAlignmentItem1;

	private ToggleTableCellsMiddleLeftAlignmentItem toggleTableCellsMiddleLeftAlignmentItem1;

	private ToggleTableCellsBottomLeftAlignmentItem toggleTableCellsBottomLeftAlignmentItem1;

	private ToggleTableCellsTopCenterAlignmentItem toggleTableCellsTopCenterAlignmentItem1;

	private ToggleTableCellsMiddleCenterAlignmentItem toggleTableCellsMiddleCenterAlignmentItem1;

	private ToggleTableCellsBottomCenterAlignmentItem toggleTableCellsBottomCenterAlignmentItem1;

	private ToggleTableCellsTopRightAlignmentItem toggleTableCellsTopRightAlignmentItem1;

	private ToggleTableCellsMiddleRightAlignmentItem toggleTableCellsMiddleRightAlignmentItem1;

	private ToggleTableCellsBottomRightAlignmentItem toggleTableCellsBottomRightAlignmentItem1;

	private ShowTableOptionsFormItem showTableOptionsFormItem1;

	private UndoItem undoItem1;

	private RedoItem redoItem1;

	private QuickPrintItem quickPrintItem1;

	private PrintItem printItem1;

	private PrintPreviewItem printPreviewItem1;

	private PasteItem pasteItem1;

	private CutItem cutItem1;

	private CopyItem copyItem1;

	private PasteSpecialItem pasteSpecialItem1;

	private BarButtonGroup barButtonGroup1;

	private ChangeFontNameItem changeFontNameItem1;

	private RepositoryItemFontEdit repositoryItemFontEdit1;

	private ChangeFontSizeItem changeFontSizeItem1;

	private RepositoryItemRichEditFontSizeEdit repositoryItemRichEditFontSizeEdit1;

	private FontSizeIncreaseItem fontSizeIncreaseItem1;

	private FontSizeDecreaseItem fontSizeDecreaseItem1;

	private BarButtonGroup barButtonGroup2;

	private ToggleFontBoldItem toggleFontBoldItem1;

	private ToggleFontItalicItem toggleFontItalicItem1;

	private ToggleFontUnderlineItem toggleFontUnderlineItem1;

	private ToggleFontDoubleUnderlineItem toggleFontDoubleUnderlineItem1;

	private ToggleFontStrikeoutItem toggleFontStrikeoutItem1;

	private ToggleFontDoubleStrikeoutItem toggleFontDoubleStrikeoutItem1;

	private ToggleFontSuperscriptItem toggleFontSuperscriptItem1;

	private ToggleFontSubscriptItem toggleFontSubscriptItem1;

	private BarButtonGroup barButtonGroup3;

	private ChangeFontColorItem changeFontColorItem1;

	private ChangeFontBackColorItem changeFontBackColorItem1;

	private ChangeTextCaseItem changeTextCaseItem1;

	private MakeTextUpperCaseItem makeTextUpperCaseItem1;

	private MakeTextLowerCaseItem makeTextLowerCaseItem1;

	private CapitalizeEachWordCaseItem capitalizeEachWordCaseItem1;

	private ToggleTextCaseItem toggleTextCaseItem1;

	private ClearFormattingItem clearFormattingItem1;

	private BarButtonGroup barButtonGroup4;

	private ToggleBulletedListItem toggleBulletedListItem1;

	private ToggleNumberingListItem toggleNumberingListItem1;

	private ToggleMultiLevelListItem toggleMultiLevelListItem1;

	private BarButtonGroup barButtonGroup5;

	private DecreaseIndentItem decreaseIndentItem1;

	private IncreaseIndentItem increaseIndentItem1;

	private ToggleShowWhitespaceItem toggleShowWhitespaceItem1;

	private BarButtonGroup barButtonGroup6;

	private ToggleParagraphAlignmentLeftItem toggleParagraphAlignmentLeftItem1;

	private ToggleParagraphAlignmentCenterItem toggleParagraphAlignmentCenterItem1;

	private ToggleParagraphAlignmentRightItem toggleParagraphAlignmentRightItem1;

	private ToggleParagraphAlignmentJustifyItem toggleParagraphAlignmentJustifyItem1;

	private BarButtonGroup barButtonGroup7;

	private ChangeParagraphLineSpacingItem changeParagraphLineSpacingItem1;

	private SetSingleParagraphSpacingItem setSingleParagraphSpacingItem1;

	private SetSesquialteralParagraphSpacingItem setSesquialteralParagraphSpacingItem1;

	private SetDoubleParagraphSpacingItem setDoubleParagraphSpacingItem1;

	private ShowLineSpacingFormItem showLineSpacingFormItem1;

	private AddSpacingBeforeParagraphItem addSpacingBeforeParagraphItem1;

	private RemoveSpacingBeforeParagraphItem removeSpacingBeforeParagraphItem1;

	private AddSpacingAfterParagraphItem addSpacingAfterParagraphItem1;

	private RemoveSpacingAfterParagraphItem removeSpacingAfterParagraphItem1;

	private ChangeParagraphBackColorItem changeParagraphBackColorItem1;

	private GalleryChangeStyleItem galleryChangeStyleItem1;

	private FindItem findItem1;

	private ReplaceItem replaceItem1;

	private InsertPageBreakItem2 insertPageBreakItem21;

	private InsertTableItem insertTableItem1;

	private InsertPictureItem insertPictureItem1;

	private InsertFloatingPictureItem insertFloatingPictureItem1;

	private InsertBookmarkItem insertBookmarkItem1;

	private InsertHyperlinkItem insertHyperlinkItem1;

	private EditPageHeaderItem editPageHeaderItem1;

	private EditPageFooterItem editPageFooterItem1;

	private InsertPageNumberItem insertPageNumberItem1;

	private InsertPageCountItem insertPageCountItem1;

	private InsertTextBoxItem insertTextBoxItem1;

	private InsertSymbolItem insertSymbolItem1;

	private InsertTableOfContentsItem insertTableOfContentsItem1;

	private UpdateTableOfContentsItem updateTableOfContentsItem1;

	private AddParagraphsToTableOfContentItem addParagraphsToTableOfContentItem1;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem1;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem2;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem3;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem4;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem5;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem6;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem7;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem8;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem9;

	private SetParagraphHeadingLevelItem setParagraphHeadingLevelItem10;

	private InsertCaptionPlaceholderItem insertCaptionPlaceholderItem1;

	private InsertFiguresCaptionItems insertFiguresCaptionItems1;

	private InsertTablesCaptionItems insertTablesCaptionItems1;

	private InsertEquationsCaptionItems insertEquationsCaptionItems1;

	private InsertTableOfFiguresPlaceholderItem insertTableOfFiguresPlaceholderItem1;

	private InsertTableOfFiguresItems insertTableOfFiguresItems1;

	private InsertTableOfTablesItems insertTableOfTablesItems1;

	private InsertTableOfEquationsItems insertTableOfEquationsItems1;

	private UpdateTableOfFiguresItem updateTableOfFiguresItem1;

	private CheckSpellingItem checkSpellingItem1;

	private ChangeLanguageItem changeLanguageItem1;

	private ProtectDocumentItem protectDocumentItem1;

	private ChangeRangeEditingPermissionsItem changeRangeEditingPermissionsItem1;

	private UnprotectDocumentItem unprotectDocumentItem1;

	private ChangeCommentItem changeCommentItem1;

	private ReviewersItem reviewersItem1;

	private ReviewingPaneItem reviewingPaneItem1;

	private ChangeFloatingObjectFillColorItem changeFloatingObjectFillColorItem1;

	private ChangeFloatingObjectOutlineColorItem changeFloatingObjectOutlineColorItem1;

	private ChangeFloatingObjectOutlineWeightItem changeFloatingObjectOutlineWeightItem1;

	private RepositoryItemFloatingObjectOutlineWeight repositoryItemFloatingObjectOutlineWeight1;

	private ChangeFloatingObjectTextWrapTypeItem changeFloatingObjectTextWrapTypeItem1;

	private SetFloatingObjectSquareTextWrapTypeItem setFloatingObjectSquareTextWrapTypeItem1;

	private SetFloatingObjectTightTextWrapTypeItem setFloatingObjectTightTextWrapTypeItem1;

	private SetFloatingObjectThroughTextWrapTypeItem setFloatingObjectThroughTextWrapTypeItem1;

	private SetFloatingObjectTopAndBottomTextWrapTypeItem setFloatingObjectTopAndBottomTextWrapTypeItem1;

	private SetFloatingObjectBehindTextWrapTypeItem setFloatingObjectBehindTextWrapTypeItem1;

	private SetFloatingObjectInFrontOfTextWrapTypeItem setFloatingObjectInFrontOfTextWrapTypeItem1;

	private ChangeFloatingObjectAlignmentItem changeFloatingObjectAlignmentItem1;

	private SetFloatingObjectTopLeftAlignmentItem setFloatingObjectTopLeftAlignmentItem1;

	private SetFloatingObjectTopCenterAlignmentItem setFloatingObjectTopCenterAlignmentItem1;

	private SetFloatingObjectTopRightAlignmentItem setFloatingObjectTopRightAlignmentItem1;

	private SetFloatingObjectMiddleLeftAlignmentItem setFloatingObjectMiddleLeftAlignmentItem1;

	private SetFloatingObjectMiddleCenterAlignmentItem setFloatingObjectMiddleCenterAlignmentItem1;

	private SetFloatingObjectMiddleRightAlignmentItem setFloatingObjectMiddleRightAlignmentItem1;

	private SetFloatingObjectBottomLeftAlignmentItem setFloatingObjectBottomLeftAlignmentItem1;

	private SetFloatingObjectBottomCenterAlignmentItem setFloatingObjectBottomCenterAlignmentItem1;

	private SetFloatingObjectBottomRightAlignmentItem setFloatingObjectBottomRightAlignmentItem1;

	private FloatingObjectBringForwardSubItem floatingObjectBringForwardSubItem1;

	private FloatingObjectBringForwardItem floatingObjectBringForwardItem1;

	private FloatingObjectBringToFrontItem floatingObjectBringToFrontItem1;

	private FloatingObjectBringInFrontOfTextItem floatingObjectBringInFrontOfTextItem1;

	private FloatingObjectSendBackwardSubItem floatingObjectSendBackwardSubItem1;

	private FloatingObjectSendBackwardItem floatingObjectSendBackwardItem1;

	private FloatingObjectSendToBackItem floatingObjectSendToBackItem1;

	private FloatingObjectSendBehindTextItem floatingObjectSendBehindTextItem1;

	private HeaderFooterToolsRibbonPageCategory headerFooterToolsRibbonPageCategory1;

	private HeaderFooterToolsDesignRibbonPage headerFooterToolsDesignRibbonPage1;

	private HeaderFooterToolsDesignNavigationRibbonPageGroup headerFooterToolsDesignNavigationRibbonPageGroup1;

	private HeaderFooterToolsDesignOptionsRibbonPageGroup headerFooterToolsDesignOptionsRibbonPageGroup1;

	private HeaderFooterToolsDesignCloseRibbonPageGroup headerFooterToolsDesignCloseRibbonPageGroup1;

	private TableToolsRibbonPageCategory tableToolsRibbonPageCategory1;

	private TableDesignRibbonPage tableDesignRibbonPage1;

	private TableStyleOptionsRibbonPageGroup tableStyleOptionsRibbonPageGroup1;

	private TableStylesRibbonPageGroup tableStylesRibbonPageGroup1;

	private TableDrawBordersRibbonPageGroup tableDrawBordersRibbonPageGroup1;

	private TableLayoutRibbonPage tableLayoutRibbonPage1;

	private TableTableRibbonPageGroup tableTableRibbonPageGroup1;

	private TableRowsAndColumnsRibbonPageGroup tableRowsAndColumnsRibbonPageGroup1;

	private TableMergeRibbonPageGroup tableMergeRibbonPageGroup1;

	private TableCellSizeRibbonPageGroup tableCellSizeRibbonPageGroup1;

	private TableAlignmentRibbonPageGroup tableAlignmentRibbonPageGroup1;

	private FloatingPictureToolsRibbonPageCategory floatingPictureToolsRibbonPageCategory1;

	private FloatingPictureToolsFormatPage floatingPictureToolsFormatPage1;

	private FloatingPictureToolsShapeStylesPageGroup floatingPictureToolsShapeStylesPageGroup1;

	private FloatingPictureToolsArrangePageGroup floatingPictureToolsArrangePageGroup1;

	private HomeRibbonPage homeRibbonPage1;

	private ClipboardRibbonPageGroup clipboardRibbonPageGroup1;

	private FontRibbonPageGroup fontRibbonPageGroup1;

	private ParagraphRibbonPageGroup paragraphRibbonPageGroup1;

	private StylesRibbonPageGroup stylesRibbonPageGroup1;

	private EditingRibbonPageGroup editingRibbonPageGroup1;

	private PageLayoutRibbonPage pageLayoutRibbonPage1;

	private PageSetupRibbonPageGroup pageSetupRibbonPageGroup1;

	private PageBackgroundRibbonPageGroup pageBackgroundRibbonPageGroup1;

	private ViewRibbonPage viewRibbonPage1;

	private DocumentViewsRibbonPageGroup documentViewsRibbonPageGroup1;

	private ShowRibbonPageGroup showRibbonPageGroup1;

	private ZoomRibbonPageGroup zoomRibbonPageGroup1;

	private InsertRibbonPage insertRibbonPage1;

	private PagesRibbonPageGroup pagesRibbonPageGroup1;

	private TablesRibbonPageGroup tablesRibbonPageGroup1;

	private IllustrationsRibbonPageGroup illustrationsRibbonPageGroup1;

	private LinksRibbonPageGroup linksRibbonPageGroup1;

	private HeaderFooterRibbonPageGroup headerFooterRibbonPageGroup1;

	private TextRibbonPageGroup textRibbonPageGroup1;

	private SymbolsRibbonPageGroup symbolsRibbonPageGroup1;

	private ReferencesRibbonPage referencesRibbonPage1;

	private TableOfContentsRibbonPageGroup tableOfContentsRibbonPageGroup1;

	private CaptionsRibbonPageGroup captionsRibbonPageGroup1;

	private ReviewRibbonPage reviewRibbonPage1;

	private DocumentProofingRibbonPageGroup documentProofingRibbonPageGroup1;

	private DocumentProtectionRibbonPageGroup documentProtectionRibbonPageGroup1;

	private DocumentTrackingRibbonPageGroup documentTrackingRibbonPageGroup1;

	private RichEditBarController richEditBarController1;

	public Stream DocumentoEditado
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Stream stream = new MemoryStream();
			rcDocumento.SaveDocument(stream, DocumentFormat.Rtf);
			return stream;
		}
	}

	public ucWord()
	{
		InitializeComponent();
	}

	public void CarregarDocumento(Stream documento)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		rcDocumento.LoadDocument(documento, DocumentFormat.Rtf);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((XtraUserControl)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Expected O, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected O, but got Unknown
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected O, but got Unknown
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Expected O, but got Unknown
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected O, but got Unknown
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected O, but got Unknown
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Expected O, but got Unknown
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Expected O, but got Unknown
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Expected O, but got Unknown
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Expected O, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Expected O, but got Unknown
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected O, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Expected O, but got Unknown
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Expected O, but got Unknown
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Expected O, but got Unknown
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Expected O, but got Unknown
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Expected O, but got Unknown
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Expected O, but got Unknown
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Expected O, but got Unknown
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Expected O, but got Unknown
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Expected O, but got Unknown
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Expected O, but got Unknown
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Expected O, but got Unknown
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Expected O, but got Unknown
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected O, but got Unknown
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Expected O, but got Unknown
		//IL_0624: Unknown result type (might be due to invalid IL or missing references)
		//IL_062e: Expected O, but got Unknown
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Expected O, but got Unknown
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Expected O, but got Unknown
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected O, but got Unknown
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Expected O, but got Unknown
		//IL_0687: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Expected O, but got Unknown
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Expected O, but got Unknown
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b2: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected O, but got Unknown
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Expected O, but got Unknown
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06de: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Expected O, but got Unknown
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Expected O, but got Unknown
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Expected O, but got Unknown
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Expected O, but got Unknown
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected O, but got Unknown
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Expected O, but got Unknown
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Expected O, but got Unknown
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Expected O, but got Unknown
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Expected O, but got Unknown
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Expected O, but got Unknown
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Expected O, but got Unknown
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_076d: Expected O, but got Unknown
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0778: Expected O, but got Unknown
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Expected O, but got Unknown
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_078e: Expected O, but got Unknown
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Expected O, but got Unknown
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a4: Expected O, but got Unknown
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected O, but got Unknown
		//IL_07b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ba: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d0: Expected O, but got Unknown
		//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07db: Expected O, but got Unknown
		//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e6: Expected O, but got Unknown
		//IL_07e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Expected O, but got Unknown
		//IL_07f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Expected O, but got Unknown
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0807: Expected O, but got Unknown
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_0812: Expected O, but got Unknown
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_081d: Expected O, but got Unknown
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Expected O, but got Unknown
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Expected O, but got Unknown
		//IL_0834: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Expected O, but got Unknown
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Expected O, but got Unknown
		//IL_084a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Expected O, but got Unknown
		//IL_0855: Unknown result type (might be due to invalid IL or missing references)
		//IL_085f: Expected O, but got Unknown
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Expected O, but got Unknown
		//IL_086b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Expected O, but got Unknown
		//IL_0876: Unknown result type (might be due to invalid IL or missing references)
		//IL_0880: Expected O, but got Unknown
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected O, but got Unknown
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Expected O, but got Unknown
		//IL_0897: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Expected O, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ac: Expected O, but got Unknown
		//IL_08ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b7: Expected O, but got Unknown
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Expected O, but got Unknown
		//IL_08c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Expected O, but got Unknown
		//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d8: Expected O, but got Unknown
		//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e3: Expected O, but got Unknown
		//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Expected O, but got Unknown
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Expected O, but got Unknown
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Expected O, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected O, but got Unknown
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_091a: Expected O, but got Unknown
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Expected O, but got Unknown
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_0930: Expected O, but got Unknown
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Expected O, but got Unknown
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0946: Expected O, but got Unknown
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		//IL_0951: Expected O, but got Unknown
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Expected O, but got Unknown
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Expected O, but got Unknown
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_0972: Expected O, but got Unknown
		//IL_0973: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Expected O, but got Unknown
		//IL_097e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0988: Expected O, but got Unknown
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Expected O, but got Unknown
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_099e: Expected O, but got Unknown
		//IL_099f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Expected O, but got Unknown
		//IL_09aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected O, but got Unknown
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bf: Expected O, but got Unknown
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ca: Expected O, but got Unknown
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Expected O, but got Unknown
		//IL_09d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Expected O, but got Unknown
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09eb: Expected O, but got Unknown
		//IL_09ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f6: Expected O, but got Unknown
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected O, but got Unknown
		//IL_0a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0c: Expected O, but got Unknown
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Expected O, but got Unknown
		//IL_0a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a22: Expected O, but got Unknown
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Expected O, but got Unknown
		//IL_0a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Expected O, but got Unknown
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Expected O, but got Unknown
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4e: Expected O, but got Unknown
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Expected O, but got Unknown
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Expected O, but got Unknown
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6f: Expected O, but got Unknown
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected O, but got Unknown
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a85: Expected O, but got Unknown
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a90: Expected O, but got Unknown
		//IL_0a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9b: Expected O, but got Unknown
		//IL_0a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa6: Expected O, but got Unknown
		//IL_0aa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Expected O, but got Unknown
		//IL_0ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abc: Expected O, but got Unknown
		//IL_0abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac7: Expected O, but got Unknown
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Expected O, but got Unknown
		//IL_0ad3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0add: Expected O, but got Unknown
		//IL_0ade: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae8: Expected O, but got Unknown
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af3: Expected O, but got Unknown
		//IL_0af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afe: Expected O, but got Unknown
		//IL_0aff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b09: Expected O, but got Unknown
		//IL_0b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b14: Expected O, but got Unknown
		//IL_0b15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1f: Expected O, but got Unknown
		//IL_0b20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2a: Expected O, but got Unknown
		//IL_0b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b35: Expected O, but got Unknown
		//IL_0b36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b40: Expected O, but got Unknown
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4b: Expected O, but got Unknown
		//IL_0b4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b56: Expected O, but got Unknown
		//IL_0b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6c: Expected O, but got Unknown
		//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b77: Expected O, but got Unknown
		//IL_0b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b82: Expected O, but got Unknown
		//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Expected O, but got Unknown
		//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba3: Expected O, but got Unknown
		//IL_0ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bae: Expected O, but got Unknown
		//IL_0baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Expected O, but got Unknown
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc4: Expected O, but got Unknown
		//IL_0bc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcf: Expected O, but got Unknown
		//IL_0bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bda: Expected O, but got Unknown
		//IL_0bdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be5: Expected O, but got Unknown
		//IL_0be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf0: Expected O, but got Unknown
		//IL_0bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfb: Expected O, but got Unknown
		//IL_0bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c06: Expected O, but got Unknown
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c11: Expected O, but got Unknown
		//IL_0c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1c: Expected O, but got Unknown
		//IL_0c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c27: Expected O, but got Unknown
		//IL_0c28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c32: Expected O, but got Unknown
		//IL_0c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3d: Expected O, but got Unknown
		//IL_0c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c48: Expected O, but got Unknown
		//IL_0c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c53: Expected O, but got Unknown
		//IL_0c54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5e: Expected O, but got Unknown
		//IL_0c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c69: Expected O, but got Unknown
		//IL_199e: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a4: Expected O, but got Unknown
		//IL_19ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b2: Expected O, but got Unknown
		//IL_19ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c0: Expected O, but got Unknown
		//IL_19c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ce: Expected O, but got Unknown
		//IL_19d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19dd: Expected O, but got Unknown
		//IL_1ab0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab6: Expected O, but got Unknown
		//IL_1abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac4: Expected O, but got Unknown
		//IL_1b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b64: Expected O, but got Unknown
		//IL_1b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b72: Expected O, but got Unknown
		//IL_1b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b80: Expected O, but got Unknown
		//IL_1b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8f: Expected O, but got Unknown
		//IL_1c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4f: Expected O, but got Unknown
		//IL_1c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5d: Expected O, but got Unknown
		//IL_1c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6b: Expected O, but got Unknown
		//IL_1c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c79: Expected O, but got Unknown
		//IL_1c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c87: Expected O, but got Unknown
		//IL_1d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d66: Expected O, but got Unknown
		//IL_1d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d74: Expected O, but got Unknown
		//IL_1d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d82: Expected O, but got Unknown
		//IL_1d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d90: Expected O, but got Unknown
		//IL_1d98: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9e: Expected O, but got Unknown
		//IL_1da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dad: Expected O, but got Unknown
		//IL_22d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d7: Expected O, but got Unknown
		//IL_2366: Unknown result type (might be due to invalid IL or missing references)
		//IL_236c: Expected O, but got Unknown
		//IL_23dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e2: Expected O, but got Unknown
		//IL_23ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f0: Expected O, but got Unknown
		//IL_23f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_23fe: Expected O, but got Unknown
		//IL_2406: Unknown result type (might be due to invalid IL or missing references)
		//IL_240c: Expected O, but got Unknown
		//IL_2415: Unknown result type (might be due to invalid IL or missing references)
		//IL_241b: Expected O, but got Unknown
		//IL_2423: Unknown result type (might be due to invalid IL or missing references)
		//IL_2429: Expected O, but got Unknown
		//IL_2431: Unknown result type (might be due to invalid IL or missing references)
		//IL_2437: Expected O, but got Unknown
		//IL_243f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2445: Expected O, but got Unknown
		//IL_244e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2454: Expected O, but got Unknown
		//IL_245d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2463: Expected O, but got Unknown
		//IL_246d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2473: Expected O, but got Unknown
		//IL_2625: Unknown result type (might be due to invalid IL or missing references)
		//IL_262b: Expected O, but got Unknown
		//IL_2633: Unknown result type (might be due to invalid IL or missing references)
		//IL_2639: Expected O, but got Unknown
		//IL_2641: Unknown result type (might be due to invalid IL or missing references)
		//IL_2647: Expected O, but got Unknown
		//IL_264f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2655: Expected O, but got Unknown
		//IL_272e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2734: Expected O, but got Unknown
		//IL_273c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2742: Expected O, but got Unknown
		//IL_274a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2750: Expected O, but got Unknown
		//IL_2758: Unknown result type (might be due to invalid IL or missing references)
		//IL_275e: Expected O, but got Unknown
		//IL_28f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f7: Expected O, but got Unknown
		//IL_28ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2905: Expected O, but got Unknown
		//IL_290d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2913: Expected O, but got Unknown
		//IL_2cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb9: Expected O, but got Unknown
		//IL_2d23: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d29: Expected O, but got Unknown
		//IL_3048: Unknown result type (might be due to invalid IL or missing references)
		//IL_304e: Expected O, but got Unknown
		//IL_3056: Unknown result type (might be due to invalid IL or missing references)
		//IL_305c: Expected O, but got Unknown
		//IL_3064: Unknown result type (might be due to invalid IL or missing references)
		//IL_306a: Expected O, but got Unknown
		//IL_3072: Unknown result type (might be due to invalid IL or missing references)
		//IL_3078: Expected O, but got Unknown
		//IL_348b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3491: Expected O, but got Unknown
		//IL_3499: Unknown result type (might be due to invalid IL or missing references)
		//IL_349f: Expected O, but got Unknown
		//IL_34a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ad: Expected O, but got Unknown
		//IL_34b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_34bb: Expected O, but got Unknown
		//IL_34c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_34c9: Expected O, but got Unknown
		//IL_34d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_34d7: Expected O, but got Unknown
		//IL_34df: Unknown result type (might be due to invalid IL or missing references)
		//IL_34e5: Expected O, but got Unknown
		//IL_34ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_34f3: Expected O, but got Unknown
		//IL_3887: Unknown result type (might be due to invalid IL or missing references)
		//IL_388d: Expected O, but got Unknown
		//IL_3895: Unknown result type (might be due to invalid IL or missing references)
		//IL_389b: Expected O, but got Unknown
		//IL_38a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_38a9: Expected O, but got Unknown
		//IL_38b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_38b7: Expected O, but got Unknown
		//IL_38bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_38c5: Expected O, but got Unknown
		//IL_38cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_38d3: Expected O, but got Unknown
		//IL_38db: Unknown result type (might be due to invalid IL or missing references)
		//IL_38e1: Expected O, but got Unknown
		//IL_38e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ef: Expected O, but got Unknown
		//IL_38f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_38fd: Expected O, but got Unknown
		//IL_3906: Unknown result type (might be due to invalid IL or missing references)
		//IL_390c: Expected O, but got Unknown
		//IL_3b24: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b2a: Expected O, but got Unknown
		//IL_3b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b38: Expected O, but got Unknown
		//IL_3b40: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b46: Expected O, but got Unknown
		//IL_3bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bf3: Expected O, but got Unknown
		//IL_3bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c01: Expected O, but got Unknown
		//IL_3c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c0f: Expected O, but got Unknown
		//IL_3e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e71: Expected O, but got Unknown
		//IL_3ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eca: Expected O, but got Unknown
		//IL_3ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ed8: Expected O, but got Unknown
		//IL_3ee0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ee6: Expected O, but got Unknown
		//IL_3eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ef4: Expected O, but got Unknown
		//IL_3efc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f02: Expected O, but got Unknown
		//IL_3f0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f10: Expected O, but got Unknown
		//IL_401e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4024: Expected O, but got Unknown
		//IL_402c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4032: Expected O, but got Unknown
		//IL_403a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4040: Expected O, but got Unknown
		//IL_4048: Unknown result type (might be due to invalid IL or missing references)
		//IL_404e: Expected O, but got Unknown
		//IL_4056: Unknown result type (might be due to invalid IL or missing references)
		//IL_405c: Expected O, but got Unknown
		//IL_4064: Unknown result type (might be due to invalid IL or missing references)
		//IL_406a: Expected O, but got Unknown
		//IL_4072: Unknown result type (might be due to invalid IL or missing references)
		//IL_4078: Expected O, but got Unknown
		//IL_4080: Unknown result type (might be due to invalid IL or missing references)
		//IL_4086: Expected O, but got Unknown
		//IL_408e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4094: Expected O, but got Unknown
		//IL_4207: Unknown result type (might be due to invalid IL or missing references)
		//IL_420d: Expected O, but got Unknown
		//IL_4215: Unknown result type (might be due to invalid IL or missing references)
		//IL_421b: Expected O, but got Unknown
		//IL_4223: Unknown result type (might be due to invalid IL or missing references)
		//IL_4229: Expected O, but got Unknown
		//IL_42d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_42d6: Expected O, but got Unknown
		//IL_42de: Unknown result type (might be due to invalid IL or missing references)
		//IL_42e4: Expected O, but got Unknown
		//IL_42ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_42f2: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ucWord));
		GalleryItemGroup val = new GalleryItemGroup();
		GalleryItemGroup val2 = new GalleryItemGroup();
		BorderInfo val3 = new BorderInfo();
		ReduceOperation val4 = new ReduceOperation();
		stylesRibbonPageGroup1 = new StylesRibbonPageGroup();
		galleryChangeStyleItem1 = new GalleryChangeStyleItem();
		rcDocumento = new RichEditControl();
		ribbonControl1 = new RibbonControl();
		changeSectionPageMarginsItem1 = new ChangeSectionPageMarginsItem();
		setNormalSectionPageMarginsItem1 = new SetNormalSectionPageMarginsItem();
		setNarrowSectionPageMarginsItem1 = new SetNarrowSectionPageMarginsItem();
		setModerateSectionPageMarginsItem1 = new SetModerateSectionPageMarginsItem();
		setWideSectionPageMarginsItem1 = new SetWideSectionPageMarginsItem();
		showPageMarginsSetupFormItem1 = new ShowPageMarginsSetupFormItem();
		changeSectionPageOrientationItem1 = new ChangeSectionPageOrientationItem();
		setPortraitPageOrientationItem1 = new SetPortraitPageOrientationItem();
		setLandscapePageOrientationItem1 = new SetLandscapePageOrientationItem();
		changeSectionPaperKindItem1 = new ChangeSectionPaperKindItem();
		changeSectionColumnsItem1 = new ChangeSectionColumnsItem();
		setSectionOneColumnItem1 = new SetSectionOneColumnItem();
		setSectionTwoColumnsItem1 = new SetSectionTwoColumnsItem();
		setSectionThreeColumnsItem1 = new SetSectionThreeColumnsItem();
		showColumnsSetupFormItem1 = new ShowColumnsSetupFormItem();
		insertBreakItem1 = new InsertBreakItem();
		insertPageBreakItem1 = new InsertPageBreakItem();
		insertColumnBreakItem1 = new InsertColumnBreakItem();
		insertSectionBreakNextPageItem1 = new InsertSectionBreakNextPageItem();
		insertSectionBreakEvenPageItem1 = new InsertSectionBreakEvenPageItem();
		insertSectionBreakOddPageItem1 = new InsertSectionBreakOddPageItem();
		changeSectionLineNumberingItem1 = new ChangeSectionLineNumberingItem();
		setSectionLineNumberingNoneItem1 = new SetSectionLineNumberingNoneItem();
		setSectionLineNumberingContinuousItem1 = new SetSectionLineNumberingContinuousItem();
		setSectionLineNumberingRestartNewPageItem1 = new SetSectionLineNumberingRestartNewPageItem();
		setSectionLineNumberingRestartNewSectionItem1 = new SetSectionLineNumberingRestartNewSectionItem();
		toggleParagraphSuppressLineNumbersItem1 = new ToggleParagraphSuppressLineNumbersItem();
		showLineNumberingFormItem1 = new ShowLineNumberingFormItem();
		changePageColorItem1 = new ChangePageColorItem();
		switchToSimpleViewItem1 = new SwitchToSimpleViewItem();
		switchToDraftViewItem1 = new SwitchToDraftViewItem();
		switchToPrintLayoutViewItem1 = new SwitchToPrintLayoutViewItem();
		toggleShowHorizontalRulerItem1 = new ToggleShowHorizontalRulerItem();
		toggleShowVerticalRulerItem1 = new ToggleShowVerticalRulerItem();
		zoomOutItem1 = new ZoomOutItem();
		zoomInItem1 = new ZoomInItem();
		goToPageHeaderItem1 = new GoToPageHeaderItem();
		goToPageFooterItem1 = new GoToPageFooterItem();
		goToNextHeaderFooterItem1 = new GoToNextHeaderFooterItem();
		goToPreviousHeaderFooterItem1 = new GoToPreviousHeaderFooterItem();
		toggleLinkToPreviousItem1 = new ToggleLinkToPreviousItem();
		toggleDifferentFirstPageItem1 = new ToggleDifferentFirstPageItem();
		toggleDifferentOddAndEvenPagesItem1 = new ToggleDifferentOddAndEvenPagesItem();
		closePageHeaderFooterItem1 = new ClosePageHeaderFooterItem();
		toggleFirstRowItem1 = new ToggleFirstRowItem();
		toggleLastRowItem1 = new ToggleLastRowItem();
		toggleBandedRowsItem1 = new ToggleBandedRowsItem();
		toggleFirstColumnItem1 = new ToggleFirstColumnItem();
		toggleLastColumnItem1 = new ToggleLastColumnItem();
		toggleBandedColumnsItem1 = new ToggleBandedColumnsItem();
		galleryChangeTableStyleItem1 = new GalleryChangeTableStyleItem();
		changeTableBorderLineStyleItem1 = new ChangeTableBorderLineStyleItem();
		repositoryItemBorderLineStyle1 = new RepositoryItemBorderLineStyle();
		changeTableBorderLineWeightItem1 = new ChangeTableBorderLineWeightItem();
		repositoryItemBorderLineWeight1 = new RepositoryItemBorderLineWeight();
		changeTableBorderColorItem1 = new ChangeTableBorderColorItem();
		changeTableBordersItem1 = new ChangeTableBordersItem();
		toggleTableCellsBottomBorderItem1 = new ToggleTableCellsBottomBorderItem();
		toggleTableCellsTopBorderItem1 = new ToggleTableCellsTopBorderItem();
		toggleTableCellsLeftBorderItem1 = new ToggleTableCellsLeftBorderItem();
		toggleTableCellsRightBorderItem1 = new ToggleTableCellsRightBorderItem();
		resetTableCellsAllBordersItem1 = new ResetTableCellsAllBordersItem();
		toggleTableCellsAllBordersItem1 = new ToggleTableCellsAllBordersItem();
		toggleTableCellsOutsideBorderItem1 = new ToggleTableCellsOutsideBorderItem();
		toggleTableCellsInsideBorderItem1 = new ToggleTableCellsInsideBorderItem();
		toggleTableCellsInsideHorizontalBorderItem1 = new ToggleTableCellsInsideHorizontalBorderItem();
		toggleTableCellsInsideVerticalBorderItem1 = new ToggleTableCellsInsideVerticalBorderItem();
		toggleShowTableGridLinesItem1 = new ToggleShowTableGridLinesItem();
		changeTableCellsShadingItem1 = new ChangeTableCellsShadingItem();
		selectTableElementsItem1 = new SelectTableElementsItem();
		selectTableCellItem1 = new SelectTableCellItem();
		selectTableColumnItem1 = new SelectTableColumnItem();
		selectTableRowItem1 = new SelectTableRowItem();
		selectTableItem1 = new SelectTableItem();
		showTablePropertiesFormItem1 = new ShowTablePropertiesFormItem();
		deleteTableElementsItem1 = new DeleteTableElementsItem();
		showDeleteTableCellsFormItem1 = new ShowDeleteTableCellsFormItem();
		deleteTableColumnsItem1 = new DeleteTableColumnsItem();
		deleteTableRowsItem1 = new DeleteTableRowsItem();
		deleteTableItem1 = new DeleteTableItem();
		insertTableRowAboveItem1 = new InsertTableRowAboveItem();
		insertTableRowBelowItem1 = new InsertTableRowBelowItem();
		insertTableColumnToLeftItem1 = new InsertTableColumnToLeftItem();
		insertTableColumnToRightItem1 = new InsertTableColumnToRightItem();
		mergeTableCellsItem1 = new MergeTableCellsItem();
		showSplitTableCellsForm1 = new ShowSplitTableCellsForm();
		splitTableItem1 = new SplitTableItem();
		toggleTableAutoFitItem1 = new ToggleTableAutoFitItem();
		toggleTableAutoFitContentsItem1 = new ToggleTableAutoFitContentsItem();
		toggleTableAutoFitWindowItem1 = new ToggleTableAutoFitWindowItem();
		toggleTableFixedColumnWidthItem1 = new ToggleTableFixedColumnWidthItem();
		toggleTableCellsTopLeftAlignmentItem1 = new ToggleTableCellsTopLeftAlignmentItem();
		toggleTableCellsMiddleLeftAlignmentItem1 = new ToggleTableCellsMiddleLeftAlignmentItem();
		toggleTableCellsBottomLeftAlignmentItem1 = new ToggleTableCellsBottomLeftAlignmentItem();
		toggleTableCellsTopCenterAlignmentItem1 = new ToggleTableCellsTopCenterAlignmentItem();
		toggleTableCellsMiddleCenterAlignmentItem1 = new ToggleTableCellsMiddleCenterAlignmentItem();
		toggleTableCellsBottomCenterAlignmentItem1 = new ToggleTableCellsBottomCenterAlignmentItem();
		toggleTableCellsTopRightAlignmentItem1 = new ToggleTableCellsTopRightAlignmentItem();
		toggleTableCellsMiddleRightAlignmentItem1 = new ToggleTableCellsMiddleRightAlignmentItem();
		toggleTableCellsBottomRightAlignmentItem1 = new ToggleTableCellsBottomRightAlignmentItem();
		showTableOptionsFormItem1 = new ShowTableOptionsFormItem();
		undoItem1 = new UndoItem();
		redoItem1 = new RedoItem();
		quickPrintItem1 = new QuickPrintItem();
		printItem1 = new PrintItem();
		printPreviewItem1 = new PrintPreviewItem();
		pasteItem1 = new PasteItem();
		cutItem1 = new CutItem();
		copyItem1 = new CopyItem();
		pasteSpecialItem1 = new PasteSpecialItem();
		barButtonGroup1 = new BarButtonGroup();
		changeFontNameItem1 = new ChangeFontNameItem();
		repositoryItemFontEdit1 = new RepositoryItemFontEdit();
		changeFontSizeItem1 = new ChangeFontSizeItem();
		repositoryItemRichEditFontSizeEdit1 = new RepositoryItemRichEditFontSizeEdit();
		fontSizeIncreaseItem1 = new FontSizeIncreaseItem();
		fontSizeDecreaseItem1 = new FontSizeDecreaseItem();
		barButtonGroup2 = new BarButtonGroup();
		toggleFontBoldItem1 = new ToggleFontBoldItem();
		toggleFontItalicItem1 = new ToggleFontItalicItem();
		toggleFontUnderlineItem1 = new ToggleFontUnderlineItem();
		toggleFontDoubleUnderlineItem1 = new ToggleFontDoubleUnderlineItem();
		toggleFontStrikeoutItem1 = new ToggleFontStrikeoutItem();
		toggleFontDoubleStrikeoutItem1 = new ToggleFontDoubleStrikeoutItem();
		toggleFontSuperscriptItem1 = new ToggleFontSuperscriptItem();
		toggleFontSubscriptItem1 = new ToggleFontSubscriptItem();
		barButtonGroup3 = new BarButtonGroup();
		changeFontColorItem1 = new ChangeFontColorItem();
		changeFontBackColorItem1 = new ChangeFontBackColorItem();
		changeTextCaseItem1 = new ChangeTextCaseItem();
		makeTextUpperCaseItem1 = new MakeTextUpperCaseItem();
		makeTextLowerCaseItem1 = new MakeTextLowerCaseItem();
		capitalizeEachWordCaseItem1 = new CapitalizeEachWordCaseItem();
		toggleTextCaseItem1 = new ToggleTextCaseItem();
		clearFormattingItem1 = new ClearFormattingItem();
		barButtonGroup4 = new BarButtonGroup();
		toggleBulletedListItem1 = new ToggleBulletedListItem();
		toggleNumberingListItem1 = new ToggleNumberingListItem();
		toggleMultiLevelListItem1 = new ToggleMultiLevelListItem();
		barButtonGroup5 = new BarButtonGroup();
		decreaseIndentItem1 = new DecreaseIndentItem();
		increaseIndentItem1 = new IncreaseIndentItem();
		toggleShowWhitespaceItem1 = new ToggleShowWhitespaceItem();
		barButtonGroup6 = new BarButtonGroup();
		toggleParagraphAlignmentLeftItem1 = new ToggleParagraphAlignmentLeftItem();
		toggleParagraphAlignmentCenterItem1 = new ToggleParagraphAlignmentCenterItem();
		toggleParagraphAlignmentRightItem1 = new ToggleParagraphAlignmentRightItem();
		toggleParagraphAlignmentJustifyItem1 = new ToggleParagraphAlignmentJustifyItem();
		barButtonGroup7 = new BarButtonGroup();
		changeParagraphLineSpacingItem1 = new ChangeParagraphLineSpacingItem();
		setSingleParagraphSpacingItem1 = new SetSingleParagraphSpacingItem();
		setSesquialteralParagraphSpacingItem1 = new SetSesquialteralParagraphSpacingItem();
		setDoubleParagraphSpacingItem1 = new SetDoubleParagraphSpacingItem();
		showLineSpacingFormItem1 = new ShowLineSpacingFormItem();
		addSpacingBeforeParagraphItem1 = new AddSpacingBeforeParagraphItem();
		removeSpacingBeforeParagraphItem1 = new RemoveSpacingBeforeParagraphItem();
		addSpacingAfterParagraphItem1 = new AddSpacingAfterParagraphItem();
		removeSpacingAfterParagraphItem1 = new RemoveSpacingAfterParagraphItem();
		changeParagraphBackColorItem1 = new ChangeParagraphBackColorItem();
		findItem1 = new FindItem();
		replaceItem1 = new ReplaceItem();
		insertPageBreakItem21 = new InsertPageBreakItem2();
		insertTableItem1 = new InsertTableItem();
		insertPictureItem1 = new InsertPictureItem();
		insertFloatingPictureItem1 = new InsertFloatingPictureItem();
		insertBookmarkItem1 = new InsertBookmarkItem();
		insertHyperlinkItem1 = new InsertHyperlinkItem();
		editPageHeaderItem1 = new EditPageHeaderItem();
		editPageFooterItem1 = new EditPageFooterItem();
		insertPageNumberItem1 = new InsertPageNumberItem();
		insertPageCountItem1 = new InsertPageCountItem();
		insertTextBoxItem1 = new InsertTextBoxItem();
		insertSymbolItem1 = new InsertSymbolItem();
		insertTableOfContentsItem1 = new InsertTableOfContentsItem();
		updateTableOfContentsItem1 = new UpdateTableOfContentsItem();
		addParagraphsToTableOfContentItem1 = new AddParagraphsToTableOfContentItem();
		setParagraphHeadingLevelItem1 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem2 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem3 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem4 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem5 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem6 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem7 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem8 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem9 = new SetParagraphHeadingLevelItem();
		setParagraphHeadingLevelItem10 = new SetParagraphHeadingLevelItem();
		insertCaptionPlaceholderItem1 = new InsertCaptionPlaceholderItem();
		insertFiguresCaptionItems1 = new InsertFiguresCaptionItems();
		insertTablesCaptionItems1 = new InsertTablesCaptionItems();
		insertEquationsCaptionItems1 = new InsertEquationsCaptionItems();
		insertTableOfFiguresPlaceholderItem1 = new InsertTableOfFiguresPlaceholderItem();
		insertTableOfFiguresItems1 = new InsertTableOfFiguresItems();
		insertTableOfTablesItems1 = new InsertTableOfTablesItems();
		insertTableOfEquationsItems1 = new InsertTableOfEquationsItems();
		updateTableOfFiguresItem1 = new UpdateTableOfFiguresItem();
		checkSpellingItem1 = new CheckSpellingItem();
		changeLanguageItem1 = new ChangeLanguageItem();
		protectDocumentItem1 = new ProtectDocumentItem();
		changeRangeEditingPermissionsItem1 = new ChangeRangeEditingPermissionsItem();
		unprotectDocumentItem1 = new UnprotectDocumentItem();
		changeCommentItem1 = new ChangeCommentItem();
		reviewersItem1 = new ReviewersItem();
		reviewingPaneItem1 = new ReviewingPaneItem();
		changeFloatingObjectFillColorItem1 = new ChangeFloatingObjectFillColorItem();
		changeFloatingObjectOutlineColorItem1 = new ChangeFloatingObjectOutlineColorItem();
		changeFloatingObjectOutlineWeightItem1 = new ChangeFloatingObjectOutlineWeightItem();
		repositoryItemFloatingObjectOutlineWeight1 = new RepositoryItemFloatingObjectOutlineWeight();
		changeFloatingObjectTextWrapTypeItem1 = new ChangeFloatingObjectTextWrapTypeItem();
		setFloatingObjectSquareTextWrapTypeItem1 = new SetFloatingObjectSquareTextWrapTypeItem();
		setFloatingObjectTightTextWrapTypeItem1 = new SetFloatingObjectTightTextWrapTypeItem();
		setFloatingObjectThroughTextWrapTypeItem1 = new SetFloatingObjectThroughTextWrapTypeItem();
		setFloatingObjectTopAndBottomTextWrapTypeItem1 = new SetFloatingObjectTopAndBottomTextWrapTypeItem();
		setFloatingObjectBehindTextWrapTypeItem1 = new SetFloatingObjectBehindTextWrapTypeItem();
		setFloatingObjectInFrontOfTextWrapTypeItem1 = new SetFloatingObjectInFrontOfTextWrapTypeItem();
		changeFloatingObjectAlignmentItem1 = new ChangeFloatingObjectAlignmentItem();
		setFloatingObjectTopLeftAlignmentItem1 = new SetFloatingObjectTopLeftAlignmentItem();
		setFloatingObjectTopCenterAlignmentItem1 = new SetFloatingObjectTopCenterAlignmentItem();
		setFloatingObjectTopRightAlignmentItem1 = new SetFloatingObjectTopRightAlignmentItem();
		setFloatingObjectMiddleLeftAlignmentItem1 = new SetFloatingObjectMiddleLeftAlignmentItem();
		setFloatingObjectMiddleCenterAlignmentItem1 = new SetFloatingObjectMiddleCenterAlignmentItem();
		setFloatingObjectMiddleRightAlignmentItem1 = new SetFloatingObjectMiddleRightAlignmentItem();
		setFloatingObjectBottomLeftAlignmentItem1 = new SetFloatingObjectBottomLeftAlignmentItem();
		setFloatingObjectBottomCenterAlignmentItem1 = new SetFloatingObjectBottomCenterAlignmentItem();
		setFloatingObjectBottomRightAlignmentItem1 = new SetFloatingObjectBottomRightAlignmentItem();
		floatingObjectBringForwardSubItem1 = new FloatingObjectBringForwardSubItem();
		floatingObjectBringForwardItem1 = new FloatingObjectBringForwardItem();
		floatingObjectBringToFrontItem1 = new FloatingObjectBringToFrontItem();
		floatingObjectBringInFrontOfTextItem1 = new FloatingObjectBringInFrontOfTextItem();
		floatingObjectSendBackwardSubItem1 = new FloatingObjectSendBackwardSubItem();
		floatingObjectSendBackwardItem1 = new FloatingObjectSendBackwardItem();
		floatingObjectSendToBackItem1 = new FloatingObjectSendToBackItem();
		floatingObjectSendBehindTextItem1 = new FloatingObjectSendBehindTextItem();
		headerFooterToolsRibbonPageCategory1 = new HeaderFooterToolsRibbonPageCategory();
		headerFooterToolsDesignRibbonPage1 = new HeaderFooterToolsDesignRibbonPage();
		headerFooterToolsDesignNavigationRibbonPageGroup1 = new HeaderFooterToolsDesignNavigationRibbonPageGroup();
		headerFooterToolsDesignOptionsRibbonPageGroup1 = new HeaderFooterToolsDesignOptionsRibbonPageGroup();
		headerFooterToolsDesignCloseRibbonPageGroup1 = new HeaderFooterToolsDesignCloseRibbonPageGroup();
		tableToolsRibbonPageCategory1 = new TableToolsRibbonPageCategory();
		tableDesignRibbonPage1 = new TableDesignRibbonPage();
		tableStyleOptionsRibbonPageGroup1 = new TableStyleOptionsRibbonPageGroup();
		tableStylesRibbonPageGroup1 = new TableStylesRibbonPageGroup();
		tableDrawBordersRibbonPageGroup1 = new TableDrawBordersRibbonPageGroup();
		tableLayoutRibbonPage1 = new TableLayoutRibbonPage();
		tableTableRibbonPageGroup1 = new TableTableRibbonPageGroup();
		tableRowsAndColumnsRibbonPageGroup1 = new TableRowsAndColumnsRibbonPageGroup();
		tableMergeRibbonPageGroup1 = new TableMergeRibbonPageGroup();
		tableCellSizeRibbonPageGroup1 = new TableCellSizeRibbonPageGroup();
		tableAlignmentRibbonPageGroup1 = new TableAlignmentRibbonPageGroup();
		floatingPictureToolsRibbonPageCategory1 = new FloatingPictureToolsRibbonPageCategory();
		floatingPictureToolsFormatPage1 = new FloatingPictureToolsFormatPage();
		floatingPictureToolsShapeStylesPageGroup1 = new FloatingPictureToolsShapeStylesPageGroup();
		floatingPictureToolsArrangePageGroup1 = new FloatingPictureToolsArrangePageGroup();
		homeRibbonPage1 = new HomeRibbonPage();
		clipboardRibbonPageGroup1 = new ClipboardRibbonPageGroup();
		fontRibbonPageGroup1 = new FontRibbonPageGroup();
		paragraphRibbonPageGroup1 = new ParagraphRibbonPageGroup();
		editingRibbonPageGroup1 = new EditingRibbonPageGroup();
		pageLayoutRibbonPage1 = new PageLayoutRibbonPage();
		pageSetupRibbonPageGroup1 = new PageSetupRibbonPageGroup();
		pageBackgroundRibbonPageGroup1 = new PageBackgroundRibbonPageGroup();
		viewRibbonPage1 = new ViewRibbonPage();
		documentViewsRibbonPageGroup1 = new DocumentViewsRibbonPageGroup();
		showRibbonPageGroup1 = new ShowRibbonPageGroup();
		zoomRibbonPageGroup1 = new ZoomRibbonPageGroup();
		insertRibbonPage1 = new InsertRibbonPage();
		pagesRibbonPageGroup1 = new PagesRibbonPageGroup();
		tablesRibbonPageGroup1 = new TablesRibbonPageGroup();
		illustrationsRibbonPageGroup1 = new IllustrationsRibbonPageGroup();
		linksRibbonPageGroup1 = new LinksRibbonPageGroup();
		headerFooterRibbonPageGroup1 = new HeaderFooterRibbonPageGroup();
		textRibbonPageGroup1 = new TextRibbonPageGroup();
		symbolsRibbonPageGroup1 = new SymbolsRibbonPageGroup();
		referencesRibbonPage1 = new ReferencesRibbonPage();
		tableOfContentsRibbonPageGroup1 = new TableOfContentsRibbonPageGroup();
		captionsRibbonPageGroup1 = new CaptionsRibbonPageGroup();
		reviewRibbonPage1 = new ReviewRibbonPage();
		documentProofingRibbonPageGroup1 = new DocumentProofingRibbonPageGroup();
		documentProtectionRibbonPageGroup1 = new DocumentProtectionRibbonPageGroup();
		documentTrackingRibbonPageGroup1 = new DocumentTrackingRibbonPageGroup();
		richEditBarController1 = new RichEditBarController();
		((ISupportInitialize)ribbonControl1).BeginInit();
		((ISupportInitialize)repositoryItemBorderLineStyle1).BeginInit();
		((ISupportInitialize)repositoryItemBorderLineWeight1).BeginInit();
		((ISupportInitialize)repositoryItemFontEdit1).BeginInit();
		((ISupportInitialize)repositoryItemRichEditFontSizeEdit1).BeginInit();
		((ISupportInitialize)repositoryItemFloatingObjectOutlineWeight1).BeginInit();
		((ISupportInitialize)richEditBarController1).BeginInit();
		((Control)this).SuspendLayout();
		((RibbonPageGroup)stylesRibbonPageGroup1).Glyph = (Image)componentResourceManager.GetObject("stylesRibbonPageGroup1.Glyph");
		((BarItemLinkCollection)((RibbonPageGroup)stylesRibbonPageGroup1).ItemLinks).Add((BarItem)(object)galleryChangeStyleItem1);
		((RibbonPageGroup)stylesRibbonPageGroup1).Name = "stylesRibbonPageGroup1";
		((BaseGallery)((RibbonGalleryBarItem)galleryChangeStyleItem1).Gallery).ColumnCount = 10;
		((BaseGallery)((RibbonGalleryBarItem)galleryChangeStyleItem1).Gallery).Groups.AddRange((GalleryItemGroup[])(object)new GalleryItemGroup[1] { val });
		((BaseGallery)((RibbonGalleryBarItem)galleryChangeStyleItem1).Gallery).ImageSize = new Size(65, 46);
		((BarItem)galleryChangeStyleItem1).Id = 160;
		((BarItem)galleryChangeStyleItem1).Name = "galleryChangeStyleItem1";
		((Control)(object)rcDocumento).Dock = DockStyle.Fill;
		rcDocumento.EnableToolTips = true;
		((Control)(object)rcDocumento).Location = new Point(0, 142);
		rcDocumento.MenuManager = (IDXMenuManager)(object)ribbonControl1;
		((Control)(object)rcDocumento).Name = "rcDocumento";
		((RichEditControlOptionsBase)rcDocumento.Options).Comments.Author = "";
		((Control)(object)rcDocumento).Size = new Size(787, 409);
		((Control)(object)rcDocumento).TabIndex = 0;
		rcDocumento.Unit = (DocumentUnit)2;
		((BarItem)ribbonControl1.ExpandCollapseItem).Id = 0;
		((BarItems)ribbonControl1.Items).AddRange((BarItem[])(object)new BarItem[229]
		{
			(BarItem)ribbonControl1.ExpandCollapseItem,
			(BarItem)changeSectionPageMarginsItem1,
			(BarItem)setNormalSectionPageMarginsItem1,
			(BarItem)setNarrowSectionPageMarginsItem1,
			(BarItem)setModerateSectionPageMarginsItem1,
			(BarItem)setWideSectionPageMarginsItem1,
			(BarItem)showPageMarginsSetupFormItem1,
			(BarItem)changeSectionPageOrientationItem1,
			(BarItem)setPortraitPageOrientationItem1,
			(BarItem)setLandscapePageOrientationItem1,
			(BarItem)changeSectionPaperKindItem1,
			(BarItem)changeSectionColumnsItem1,
			(BarItem)setSectionOneColumnItem1,
			(BarItem)setSectionTwoColumnsItem1,
			(BarItem)setSectionThreeColumnsItem1,
			(BarItem)showColumnsSetupFormItem1,
			(BarItem)insertBreakItem1,
			(BarItem)insertPageBreakItem1,
			(BarItem)insertColumnBreakItem1,
			(BarItem)insertSectionBreakNextPageItem1,
			(BarItem)insertSectionBreakEvenPageItem1,
			(BarItem)insertSectionBreakOddPageItem1,
			(BarItem)changeSectionLineNumberingItem1,
			(BarItem)setSectionLineNumberingNoneItem1,
			(BarItem)setSectionLineNumberingContinuousItem1,
			(BarItem)setSectionLineNumberingRestartNewPageItem1,
			(BarItem)setSectionLineNumberingRestartNewSectionItem1,
			(BarItem)toggleParagraphSuppressLineNumbersItem1,
			(BarItem)showLineNumberingFormItem1,
			(BarItem)changePageColorItem1,
			(BarItem)switchToSimpleViewItem1,
			(BarItem)switchToDraftViewItem1,
			(BarItem)switchToPrintLayoutViewItem1,
			(BarItem)toggleShowHorizontalRulerItem1,
			(BarItem)toggleShowVerticalRulerItem1,
			(BarItem)zoomOutItem1,
			(BarItem)zoomInItem1,
			(BarItem)goToPageHeaderItem1,
			(BarItem)goToPageFooterItem1,
			(BarItem)goToNextHeaderFooterItem1,
			(BarItem)goToPreviousHeaderFooterItem1,
			(BarItem)toggleLinkToPreviousItem1,
			(BarItem)toggleDifferentFirstPageItem1,
			(BarItem)toggleDifferentOddAndEvenPagesItem1,
			(BarItem)closePageHeaderFooterItem1,
			(BarItem)toggleFirstRowItem1,
			(BarItem)toggleLastRowItem1,
			(BarItem)toggleBandedRowsItem1,
			(BarItem)toggleFirstColumnItem1,
			(BarItem)toggleLastColumnItem1,
			(BarItem)toggleBandedColumnsItem1,
			(BarItem)galleryChangeTableStyleItem1,
			(BarItem)changeTableBorderLineStyleItem1,
			(BarItem)changeTableBorderLineWeightItem1,
			(BarItem)changeTableBorderColorItem1,
			(BarItem)changeTableBordersItem1,
			(BarItem)toggleTableCellsBottomBorderItem1,
			(BarItem)toggleTableCellsTopBorderItem1,
			(BarItem)toggleTableCellsLeftBorderItem1,
			(BarItem)toggleTableCellsRightBorderItem1,
			(BarItem)resetTableCellsAllBordersItem1,
			(BarItem)toggleTableCellsAllBordersItem1,
			(BarItem)toggleTableCellsOutsideBorderItem1,
			(BarItem)toggleTableCellsInsideBorderItem1,
			(BarItem)toggleTableCellsInsideHorizontalBorderItem1,
			(BarItem)toggleTableCellsInsideVerticalBorderItem1,
			(BarItem)toggleShowTableGridLinesItem1,
			(BarItem)changeTableCellsShadingItem1,
			(BarItem)selectTableElementsItem1,
			(BarItem)selectTableCellItem1,
			(BarItem)selectTableColumnItem1,
			(BarItem)selectTableRowItem1,
			(BarItem)selectTableItem1,
			(BarItem)showTablePropertiesFormItem1,
			(BarItem)deleteTableElementsItem1,
			(BarItem)showDeleteTableCellsFormItem1,
			(BarItem)deleteTableColumnsItem1,
			(BarItem)deleteTableRowsItem1,
			(BarItem)deleteTableItem1,
			(BarItem)insertTableRowAboveItem1,
			(BarItem)insertTableRowBelowItem1,
			(BarItem)insertTableColumnToLeftItem1,
			(BarItem)insertTableColumnToRightItem1,
			(BarItem)mergeTableCellsItem1,
			(BarItem)showSplitTableCellsForm1,
			(BarItem)splitTableItem1,
			(BarItem)toggleTableAutoFitItem1,
			(BarItem)toggleTableAutoFitContentsItem1,
			(BarItem)toggleTableAutoFitWindowItem1,
			(BarItem)toggleTableFixedColumnWidthItem1,
			(BarItem)toggleTableCellsTopLeftAlignmentItem1,
			(BarItem)toggleTableCellsMiddleLeftAlignmentItem1,
			(BarItem)toggleTableCellsBottomLeftAlignmentItem1,
			(BarItem)toggleTableCellsTopCenterAlignmentItem1,
			(BarItem)toggleTableCellsMiddleCenterAlignmentItem1,
			(BarItem)toggleTableCellsBottomCenterAlignmentItem1,
			(BarItem)toggleTableCellsTopRightAlignmentItem1,
			(BarItem)toggleTableCellsMiddleRightAlignmentItem1,
			(BarItem)toggleTableCellsBottomRightAlignmentItem1,
			(BarItem)showTableOptionsFormItem1,
			(BarItem)undoItem1,
			(BarItem)redoItem1,
			(BarItem)quickPrintItem1,
			(BarItem)printItem1,
			(BarItem)printPreviewItem1,
			(BarItem)pasteItem1,
			(BarItem)cutItem1,
			(BarItem)copyItem1,
			(BarItem)pasteSpecialItem1,
			(BarItem)barButtonGroup1,
			(BarItem)changeFontNameItem1,
			(BarItem)changeFontSizeItem1,
			(BarItem)fontSizeIncreaseItem1,
			(BarItem)fontSizeDecreaseItem1,
			(BarItem)barButtonGroup2,
			(BarItem)toggleFontBoldItem1,
			(BarItem)toggleFontItalicItem1,
			(BarItem)toggleFontUnderlineItem1,
			(BarItem)toggleFontDoubleUnderlineItem1,
			(BarItem)toggleFontStrikeoutItem1,
			(BarItem)toggleFontDoubleStrikeoutItem1,
			(BarItem)toggleFontSuperscriptItem1,
			(BarItem)toggleFontSubscriptItem1,
			(BarItem)barButtonGroup3,
			(BarItem)changeFontColorItem1,
			(BarItem)changeFontBackColorItem1,
			(BarItem)changeTextCaseItem1,
			(BarItem)makeTextUpperCaseItem1,
			(BarItem)makeTextLowerCaseItem1,
			(BarItem)capitalizeEachWordCaseItem1,
			(BarItem)toggleTextCaseItem1,
			(BarItem)clearFormattingItem1,
			(BarItem)barButtonGroup4,
			(BarItem)toggleBulletedListItem1,
			(BarItem)toggleNumberingListItem1,
			(BarItem)toggleMultiLevelListItem1,
			(BarItem)barButtonGroup5,
			(BarItem)decreaseIndentItem1,
			(BarItem)increaseIndentItem1,
			(BarItem)barButtonGroup6,
			(BarItem)toggleParagraphAlignmentLeftItem1,
			(BarItem)toggleParagraphAlignmentCenterItem1,
			(BarItem)toggleParagraphAlignmentRightItem1,
			(BarItem)toggleParagraphAlignmentJustifyItem1,
			(BarItem)toggleShowWhitespaceItem1,
			(BarItem)barButtonGroup7,
			(BarItem)changeParagraphLineSpacingItem1,
			(BarItem)setSingleParagraphSpacingItem1,
			(BarItem)setSesquialteralParagraphSpacingItem1,
			(BarItem)setDoubleParagraphSpacingItem1,
			(BarItem)showLineSpacingFormItem1,
			(BarItem)addSpacingBeforeParagraphItem1,
			(BarItem)removeSpacingBeforeParagraphItem1,
			(BarItem)addSpacingAfterParagraphItem1,
			(BarItem)removeSpacingAfterParagraphItem1,
			(BarItem)changeParagraphBackColorItem1,
			(BarItem)galleryChangeStyleItem1,
			(BarItem)findItem1,
			(BarItem)replaceItem1,
			(BarItem)insertPageBreakItem21,
			(BarItem)insertTableItem1,
			(BarItem)insertPictureItem1,
			(BarItem)insertFloatingPictureItem1,
			(BarItem)insertBookmarkItem1,
			(BarItem)insertHyperlinkItem1,
			(BarItem)editPageHeaderItem1,
			(BarItem)editPageFooterItem1,
			(BarItem)insertPageNumberItem1,
			(BarItem)insertPageCountItem1,
			(BarItem)insertTextBoxItem1,
			(BarItem)insertSymbolItem1,
			(BarItem)insertTableOfContentsItem1,
			(BarItem)updateTableOfContentsItem1,
			(BarItem)addParagraphsToTableOfContentItem1,
			(BarItem)setParagraphHeadingLevelItem1,
			(BarItem)setParagraphHeadingLevelItem2,
			(BarItem)setParagraphHeadingLevelItem3,
			(BarItem)setParagraphHeadingLevelItem4,
			(BarItem)setParagraphHeadingLevelItem5,
			(BarItem)setParagraphHeadingLevelItem6,
			(BarItem)setParagraphHeadingLevelItem7,
			(BarItem)setParagraphHeadingLevelItem8,
			(BarItem)setParagraphHeadingLevelItem9,
			(BarItem)setParagraphHeadingLevelItem10,
			(BarItem)insertCaptionPlaceholderItem1,
			(BarItem)insertFiguresCaptionItems1,
			(BarItem)insertTablesCaptionItems1,
			(BarItem)insertEquationsCaptionItems1,
			(BarItem)insertTableOfFiguresPlaceholderItem1,
			(BarItem)insertTableOfFiguresItems1,
			(BarItem)insertTableOfTablesItems1,
			(BarItem)insertTableOfEquationsItems1,
			(BarItem)updateTableOfFiguresItem1,
			(BarItem)checkSpellingItem1,
			(BarItem)changeLanguageItem1,
			(BarItem)protectDocumentItem1,
			(BarItem)changeRangeEditingPermissionsItem1,
			(BarItem)unprotectDocumentItem1,
			(BarItem)changeCommentItem1,
			(BarItem)reviewersItem1,
			(BarItem)reviewingPaneItem1,
			(BarItem)changeFloatingObjectFillColorItem1,
			(BarItem)changeFloatingObjectOutlineColorItem1,
			(BarItem)changeFloatingObjectOutlineWeightItem1,
			(BarItem)changeFloatingObjectTextWrapTypeItem1,
			(BarItem)setFloatingObjectSquareTextWrapTypeItem1,
			(BarItem)setFloatingObjectTightTextWrapTypeItem1,
			(BarItem)setFloatingObjectThroughTextWrapTypeItem1,
			(BarItem)setFloatingObjectTopAndBottomTextWrapTypeItem1,
			(BarItem)setFloatingObjectBehindTextWrapTypeItem1,
			(BarItem)setFloatingObjectInFrontOfTextWrapTypeItem1,
			(BarItem)changeFloatingObjectAlignmentItem1,
			(BarItem)setFloatingObjectTopLeftAlignmentItem1,
			(BarItem)setFloatingObjectTopCenterAlignmentItem1,
			(BarItem)setFloatingObjectTopRightAlignmentItem1,
			(BarItem)setFloatingObjectMiddleLeftAlignmentItem1,
			(BarItem)setFloatingObjectMiddleCenterAlignmentItem1,
			(BarItem)setFloatingObjectMiddleRightAlignmentItem1,
			(BarItem)setFloatingObjectBottomLeftAlignmentItem1,
			(BarItem)setFloatingObjectBottomCenterAlignmentItem1,
			(BarItem)setFloatingObjectBottomRightAlignmentItem1,
			(BarItem)floatingObjectBringForwardSubItem1,
			(BarItem)floatingObjectBringForwardItem1,
			(BarItem)floatingObjectBringToFrontItem1,
			(BarItem)floatingObjectBringInFrontOfTextItem1,
			(BarItem)floatingObjectSendBackwardSubItem1,
			(BarItem)floatingObjectSendBackwardItem1,
			(BarItem)floatingObjectSendToBackItem1,
			(BarItem)floatingObjectSendBehindTextItem1
		});
		((Control)(object)ribbonControl1).Location = new Point(0, 0);
		ribbonControl1.MaxItemId = 237;
		((Control)(object)ribbonControl1).Name = "ribbonControl1";
		ribbonControl1.PageCategories.AddRange((RibbonPageCategory[])(object)new RibbonPageCategory[3]
		{
			(RibbonPageCategory)headerFooterToolsRibbonPageCategory1,
			(RibbonPageCategory)tableToolsRibbonPageCategory1,
			(RibbonPageCategory)floatingPictureToolsRibbonPageCategory1
		});
		ribbonControl1.Pages.AddRange((RibbonPage[])(object)new RibbonPage[6]
		{
			(RibbonPage)homeRibbonPage1,
			(RibbonPage)pageLayoutRibbonPage1,
			(RibbonPage)viewRibbonPage1,
			(RibbonPage)insertRibbonPage1,
			(RibbonPage)referencesRibbonPage1,
			(RibbonPage)reviewRibbonPage1
		});
		ribbonControl1.RepositoryItems.AddRange((RepositoryItem[])(object)new RepositoryItem[5]
		{
			(RepositoryItem)repositoryItemBorderLineStyle1,
			(RepositoryItem)repositoryItemBorderLineWeight1,
			(RepositoryItem)repositoryItemFontEdit1,
			(RepositoryItem)repositoryItemRichEditFontSizeEdit1,
			(RepositoryItem)repositoryItemFloatingObjectOutlineWeight1
		});
		((Control)(object)ribbonControl1).Size = new Size(787, 142);
		((BarItem)changeSectionPageMarginsItem1).Id = 1;
		((BarLinkContainerItem)changeSectionPageMarginsItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[5]
		{
			new LinkPersistInfo((BarItem)(object)setNormalSectionPageMarginsItem1),
			new LinkPersistInfo((BarItem)(object)setNarrowSectionPageMarginsItem1),
			new LinkPersistInfo((BarItem)(object)setModerateSectionPageMarginsItem1),
			new LinkPersistInfo((BarItem)(object)setWideSectionPageMarginsItem1),
			new LinkPersistInfo((BarItem)(object)showPageMarginsSetupFormItem1, true)
		});
		((BarItem)changeSectionPageMarginsItem1).Name = "changeSectionPageMarginsItem1";
		((BarItem)setNormalSectionPageMarginsItem1).Id = 2;
		((BarItem)setNormalSectionPageMarginsItem1).Name = "setNormalSectionPageMarginsItem1";
		((BarItem)setNarrowSectionPageMarginsItem1).Id = 3;
		((BarItem)setNarrowSectionPageMarginsItem1).Name = "setNarrowSectionPageMarginsItem1";
		((BarItem)setModerateSectionPageMarginsItem1).Id = 4;
		((BarItem)setModerateSectionPageMarginsItem1).Name = "setModerateSectionPageMarginsItem1";
		((BarItem)setWideSectionPageMarginsItem1).Id = 5;
		((BarItem)setWideSectionPageMarginsItem1).Name = "setWideSectionPageMarginsItem1";
		((BarItem)showPageMarginsSetupFormItem1).Id = 6;
		((BarItem)showPageMarginsSetupFormItem1).Name = "showPageMarginsSetupFormItem1";
		((BarItem)changeSectionPageOrientationItem1).Id = 7;
		((BarLinkContainerItem)changeSectionPageOrientationItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[2]
		{
			new LinkPersistInfo((BarItem)(object)setPortraitPageOrientationItem1),
			new LinkPersistInfo((BarItem)(object)setLandscapePageOrientationItem1)
		});
		((BarItem)changeSectionPageOrientationItem1).Name = "changeSectionPageOrientationItem1";
		((BarItem)setPortraitPageOrientationItem1).Id = 8;
		((BarItem)setPortraitPageOrientationItem1).Name = "setPortraitPageOrientationItem1";
		((BarItem)setLandscapePageOrientationItem1).Id = 9;
		((BarItem)setLandscapePageOrientationItem1).Name = "setLandscapePageOrientationItem1";
		((BarItem)changeSectionPaperKindItem1).Id = 10;
		((BarItem)changeSectionPaperKindItem1).Name = "changeSectionPaperKindItem1";
		((BarItem)changeSectionColumnsItem1).Id = 11;
		((BarLinkContainerItem)changeSectionColumnsItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[4]
		{
			new LinkPersistInfo((BarItem)(object)setSectionOneColumnItem1),
			new LinkPersistInfo((BarItem)(object)setSectionTwoColumnsItem1),
			new LinkPersistInfo((BarItem)(object)setSectionThreeColumnsItem1),
			new LinkPersistInfo((BarItem)(object)showColumnsSetupFormItem1, true)
		});
		((BarItem)changeSectionColumnsItem1).Name = "changeSectionColumnsItem1";
		((BarItem)setSectionOneColumnItem1).Id = 12;
		((BarItem)setSectionOneColumnItem1).Name = "setSectionOneColumnItem1";
		((BarItem)setSectionTwoColumnsItem1).Id = 13;
		((BarItem)setSectionTwoColumnsItem1).Name = "setSectionTwoColumnsItem1";
		((BarItem)setSectionThreeColumnsItem1).Id = 14;
		((BarItem)setSectionThreeColumnsItem1).Name = "setSectionThreeColumnsItem1";
		((BarItem)showColumnsSetupFormItem1).Id = 15;
		((BarItem)showColumnsSetupFormItem1).Name = "showColumnsSetupFormItem1";
		((BarItem)insertBreakItem1).Id = 16;
		((BarLinkContainerItem)insertBreakItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[5]
		{
			new LinkPersistInfo((BarItem)(object)insertPageBreakItem1),
			new LinkPersistInfo((BarItem)(object)insertColumnBreakItem1),
			new LinkPersistInfo((BarItem)(object)insertSectionBreakNextPageItem1),
			new LinkPersistInfo((BarItem)(object)insertSectionBreakEvenPageItem1),
			new LinkPersistInfo((BarItem)(object)insertSectionBreakOddPageItem1)
		});
		((BarItem)insertBreakItem1).Name = "insertBreakItem1";
		((BarItem)insertPageBreakItem1).Id = 17;
		((BarItem)insertPageBreakItem1).Name = "insertPageBreakItem1";
		((BarItem)insertColumnBreakItem1).Id = 18;
		((BarItem)insertColumnBreakItem1).Name = "insertColumnBreakItem1";
		((BarItem)insertSectionBreakNextPageItem1).Id = 19;
		((BarItem)insertSectionBreakNextPageItem1).Name = "insertSectionBreakNextPageItem1";
		((BarItem)insertSectionBreakEvenPageItem1).Id = 20;
		((BarItem)insertSectionBreakEvenPageItem1).Name = "insertSectionBreakEvenPageItem1";
		((BarItem)insertSectionBreakOddPageItem1).Id = 21;
		((BarItem)insertSectionBreakOddPageItem1).Name = "insertSectionBreakOddPageItem1";
		((BarItem)changeSectionLineNumberingItem1).Id = 22;
		((BarLinkContainerItem)changeSectionLineNumberingItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[6]
		{
			new LinkPersistInfo((BarItem)(object)setSectionLineNumberingNoneItem1),
			new LinkPersistInfo((BarItem)(object)setSectionLineNumberingContinuousItem1),
			new LinkPersistInfo((BarItem)(object)setSectionLineNumberingRestartNewPageItem1),
			new LinkPersistInfo((BarItem)(object)setSectionLineNumberingRestartNewSectionItem1),
			new LinkPersistInfo((BarItem)(object)toggleParagraphSuppressLineNumbersItem1),
			new LinkPersistInfo((BarItem)(object)showLineNumberingFormItem1, true)
		});
		((BarItem)changeSectionLineNumberingItem1).Name = "changeSectionLineNumberingItem1";
		((BarItem)setSectionLineNumberingNoneItem1).Id = 23;
		((BarItem)setSectionLineNumberingNoneItem1).Name = "setSectionLineNumberingNoneItem1";
		((BarItem)setSectionLineNumberingContinuousItem1).Id = 24;
		((BarItem)setSectionLineNumberingContinuousItem1).Name = "setSectionLineNumberingContinuousItem1";
		((BarItem)setSectionLineNumberingRestartNewPageItem1).Id = 25;
		((BarItem)setSectionLineNumberingRestartNewPageItem1).Name = "setSectionLineNumberingRestartNewPageItem1";
		((BarItem)setSectionLineNumberingRestartNewSectionItem1).Id = 26;
		((BarItem)setSectionLineNumberingRestartNewSectionItem1).Name = "setSectionLineNumberingRestartNewSectionItem1";
		((BarItem)toggleParagraphSuppressLineNumbersItem1).Id = 27;
		((BarItem)toggleParagraphSuppressLineNumbersItem1).Name = "toggleParagraphSuppressLineNumbersItem1";
		((BarItem)showLineNumberingFormItem1).Id = 28;
		((BarItem)showLineNumberingFormItem1).Name = "showLineNumberingFormItem1";
		((BarItem)changePageColorItem1).Id = 29;
		((BarItem)changePageColorItem1).Name = "changePageColorItem1";
		((BarItem)switchToSimpleViewItem1).Id = 30;
		((BarItem)switchToSimpleViewItem1).Name = "switchToSimpleViewItem1";
		((BarItem)switchToDraftViewItem1).Id = 31;
		((BarItem)switchToDraftViewItem1).Name = "switchToDraftViewItem1";
		((BarItem)switchToPrintLayoutViewItem1).Id = 32;
		((BarItem)switchToPrintLayoutViewItem1).Name = "switchToPrintLayoutViewItem1";
		((BarItem)toggleShowHorizontalRulerItem1).Id = 33;
		((BarItem)toggleShowHorizontalRulerItem1).Name = "toggleShowHorizontalRulerItem1";
		((BarItem)toggleShowVerticalRulerItem1).Id = 34;
		((BarItem)toggleShowVerticalRulerItem1).Name = "toggleShowVerticalRulerItem1";
		((BarItem)zoomOutItem1).Id = 35;
		((BarItem)zoomOutItem1).Name = "zoomOutItem1";
		((BarItem)zoomInItem1).Id = 36;
		((BarItem)zoomInItem1).Name = "zoomInItem1";
		((BarItem)goToPageHeaderItem1).Id = 37;
		((BarItem)goToPageHeaderItem1).Name = "goToPageHeaderItem1";
		((BarItem)goToPageFooterItem1).Id = 38;
		((BarItem)goToPageFooterItem1).Name = "goToPageFooterItem1";
		((BarItem)goToNextHeaderFooterItem1).Id = 39;
		((BarItem)goToNextHeaderFooterItem1).Name = "goToNextHeaderFooterItem1";
		((BarItem)goToPreviousHeaderFooterItem1).Id = 40;
		((BarItem)goToPreviousHeaderFooterItem1).Name = "goToPreviousHeaderFooterItem1";
		((BarItem)toggleLinkToPreviousItem1).Id = 41;
		((BarItem)toggleLinkToPreviousItem1).Name = "toggleLinkToPreviousItem1";
		((BarItem)toggleDifferentFirstPageItem1).Id = 42;
		((BarItem)toggleDifferentFirstPageItem1).Name = "toggleDifferentFirstPageItem1";
		((BarItem)toggleDifferentOddAndEvenPagesItem1).Id = 43;
		((BarItem)toggleDifferentOddAndEvenPagesItem1).Name = "toggleDifferentOddAndEvenPagesItem1";
		((BarItem)closePageHeaderFooterItem1).Id = 44;
		((BarItem)closePageHeaderFooterItem1).Name = "closePageHeaderFooterItem1";
		((BarCheckItem)toggleFirstRowItem1).CheckBoxVisibility = (CheckBoxVisibility)1;
		((BarItem)toggleFirstRowItem1).Id = 45;
		((BarItem)toggleFirstRowItem1).Name = "toggleFirstRowItem1";
		((BarCheckItem)toggleLastRowItem1).CheckBoxVisibility = (CheckBoxVisibility)1;
		((BarItem)toggleLastRowItem1).Id = 46;
		((BarItem)toggleLastRowItem1).Name = "toggleLastRowItem1";
		((BarCheckItem)toggleBandedRowsItem1).CheckBoxVisibility = (CheckBoxVisibility)1;
		((BarItem)toggleBandedRowsItem1).Id = 47;
		((BarItem)toggleBandedRowsItem1).Name = "toggleBandedRowsItem1";
		((BarCheckItem)toggleFirstColumnItem1).CheckBoxVisibility = (CheckBoxVisibility)1;
		((BarItem)toggleFirstColumnItem1).Id = 48;
		((BarItem)toggleFirstColumnItem1).Name = "toggleFirstColumnItem1";
		((BarCheckItem)toggleLastColumnItem1).CheckBoxVisibility = (CheckBoxVisibility)1;
		((BarItem)toggleLastColumnItem1).Id = 49;
		((BarItem)toggleLastColumnItem1).Name = "toggleLastColumnItem1";
		((BarCheckItem)toggleBandedColumnsItem1).CheckBoxVisibility = (CheckBoxVisibility)1;
		((BarItem)toggleBandedColumnsItem1).Id = 50;
		((BarItem)toggleBandedColumnsItem1).Name = "toggleBandedColumnsItem1";
		((GalleryChangeTableStyleItemBase)galleryChangeTableStyleItem1).CurrentItem = null;
		galleryChangeTableStyleItem1.CurrentItemStyle = null;
		galleryChangeTableStyleItem1.CurrentStyle = null;
		((GalleryChangeTableStyleItemBase)galleryChangeTableStyleItem1).DeleteItemLink = null;
		((BaseGallery)((RibbonGalleryBarItem)galleryChangeTableStyleItem1).Gallery).ColumnCount = 3;
		((BaseGallery)((RibbonGalleryBarItem)galleryChangeTableStyleItem1).Gallery).Groups.AddRange((GalleryItemGroup[])(object)new GalleryItemGroup[1] { val2 });
		((BaseGallery)((RibbonGalleryBarItem)galleryChangeTableStyleItem1).Gallery).ImageSize = new Size(65, 46);
		((BarItem)galleryChangeTableStyleItem1).Id = 51;
		((GalleryChangeTableStyleItemBase)galleryChangeTableStyleItem1).ModifyItemLink = null;
		((BarItem)galleryChangeTableStyleItem1).Name = "galleryChangeTableStyleItem1";
		((GalleryChangeTableStyleItemBase)galleryChangeTableStyleItem1).NewItemLink = null;
		((GalleryChangeTableStyleItemBase)galleryChangeTableStyleItem1).PopupGallery = null;
		((BarEditItem)changeTableBorderLineStyleItem1).Edit = (RepositoryItem)(object)repositoryItemBorderLineStyle1;
		val3.Color = Color.Black;
		val3.Frame = false;
		val3.Offset = 0;
		val3.Shadow = false;
		val3.Style = (BorderLineStyle)1;
		val3.Width = 10;
		((BarEditItem)changeTableBorderLineStyleItem1).EditValue = val3;
		((BarItem)changeTableBorderLineStyleItem1).Id = 52;
		((BarItem)changeTableBorderLineStyleItem1).Name = "changeTableBorderLineStyleItem1";
		((RepositoryItem)repositoryItemBorderLineStyle1).AutoHeight = false;
		((RepositoryItemButtonEdit)repositoryItemBorderLineStyle1).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		repositoryItemBorderLineStyle1.Control = rcDocumento;
		((RepositoryItem)repositoryItemBorderLineStyle1).Name = "repositoryItemBorderLineStyle1";
		((BarEditItem)changeTableBorderLineWeightItem1).Edit = (RepositoryItem)(object)repositoryItemBorderLineWeight1;
		((BarEditItem)changeTableBorderLineWeightItem1).EditValue = 20;
		((BarItem)changeTableBorderLineWeightItem1).Id = 53;
		((BarItem)changeTableBorderLineWeightItem1).Name = "changeTableBorderLineWeightItem1";
		((RepositoryItem)repositoryItemBorderLineWeight1).AutoHeight = false;
		((RepositoryItemButtonEdit)repositoryItemBorderLineWeight1).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		repositoryItemBorderLineWeight1.Control = rcDocumento;
		((RepositoryItem)repositoryItemBorderLineWeight1).Name = "repositoryItemBorderLineWeight1";
		((BarItem)changeTableBorderColorItem1).Id = 54;
		((BarItem)changeTableBorderColorItem1).Name = "changeTableBorderColorItem1";
		((BarItem)changeTableBordersItem1).Id = 55;
		((BarLinkContainerItem)changeTableBordersItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[11]
		{
			new LinkPersistInfo((BarItem)(object)toggleTableCellsBottomBorderItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsTopBorderItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsLeftBorderItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsRightBorderItem1),
			new LinkPersistInfo((BarItem)(object)resetTableCellsAllBordersItem1, true),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsAllBordersItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsOutsideBorderItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsInsideBorderItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsInsideHorizontalBorderItem1, true),
			new LinkPersistInfo((BarItem)(object)toggleTableCellsInsideVerticalBorderItem1),
			new LinkPersistInfo((BarItem)(object)toggleShowTableGridLinesItem1, true)
		});
		((BarItem)changeTableBordersItem1).Name = "changeTableBordersItem1";
		((BarItem)toggleTableCellsBottomBorderItem1).Id = 56;
		((BarItem)toggleTableCellsBottomBorderItem1).Name = "toggleTableCellsBottomBorderItem1";
		((BarItem)toggleTableCellsTopBorderItem1).Id = 57;
		((BarItem)toggleTableCellsTopBorderItem1).Name = "toggleTableCellsTopBorderItem1";
		((BarItem)toggleTableCellsLeftBorderItem1).Id = 58;
		((BarItem)toggleTableCellsLeftBorderItem1).Name = "toggleTableCellsLeftBorderItem1";
		((BarItem)toggleTableCellsRightBorderItem1).Id = 59;
		((BarItem)toggleTableCellsRightBorderItem1).Name = "toggleTableCellsRightBorderItem1";
		((BarItem)resetTableCellsAllBordersItem1).Id = 60;
		((BarItem)resetTableCellsAllBordersItem1).Name = "resetTableCellsAllBordersItem1";
		((BarItem)toggleTableCellsAllBordersItem1).Id = 61;
		((BarItem)toggleTableCellsAllBordersItem1).Name = "toggleTableCellsAllBordersItem1";
		((BarItem)toggleTableCellsOutsideBorderItem1).Id = 62;
		((BarItem)toggleTableCellsOutsideBorderItem1).Name = "toggleTableCellsOutsideBorderItem1";
		((BarItem)toggleTableCellsInsideBorderItem1).Id = 63;
		((BarItem)toggleTableCellsInsideBorderItem1).Name = "toggleTableCellsInsideBorderItem1";
		((BarItem)toggleTableCellsInsideHorizontalBorderItem1).Id = 64;
		((BarItem)toggleTableCellsInsideHorizontalBorderItem1).Name = "toggleTableCellsInsideHorizontalBorderItem1";
		((BarItem)toggleTableCellsInsideVerticalBorderItem1).Id = 65;
		((BarItem)toggleTableCellsInsideVerticalBorderItem1).Name = "toggleTableCellsInsideVerticalBorderItem1";
		((BarItem)toggleShowTableGridLinesItem1).Id = 66;
		((BarItem)toggleShowTableGridLinesItem1).Name = "toggleShowTableGridLinesItem1";
		((BarItem)changeTableCellsShadingItem1).Id = 67;
		((BarItem)changeTableCellsShadingItem1).Name = "changeTableCellsShadingItem1";
		((BarItem)selectTableElementsItem1).Id = 68;
		((BarLinkContainerItem)selectTableElementsItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[4]
		{
			new LinkPersistInfo((BarItem)(object)selectTableCellItem1),
			new LinkPersistInfo((BarItem)(object)selectTableColumnItem1),
			new LinkPersistInfo((BarItem)(object)selectTableRowItem1),
			new LinkPersistInfo((BarItem)(object)selectTableItem1)
		});
		((BarItem)selectTableElementsItem1).Name = "selectTableElementsItem1";
		((BarItem)selectTableCellItem1).Id = 69;
		((BarItem)selectTableCellItem1).Name = "selectTableCellItem1";
		((BarItem)selectTableColumnItem1).Id = 70;
		((BarItem)selectTableColumnItem1).Name = "selectTableColumnItem1";
		((BarItem)selectTableRowItem1).Id = 71;
		((BarItem)selectTableRowItem1).Name = "selectTableRowItem1";
		((BarItem)selectTableItem1).Id = 72;
		((BarItem)selectTableItem1).Name = "selectTableItem1";
		((BarItem)showTablePropertiesFormItem1).Id = 73;
		((BarItem)showTablePropertiesFormItem1).Name = "showTablePropertiesFormItem1";
		((BarItem)deleteTableElementsItem1).Id = 74;
		((BarLinkContainerItem)deleteTableElementsItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[4]
		{
			new LinkPersistInfo((BarItem)(object)showDeleteTableCellsFormItem1),
			new LinkPersistInfo((BarItem)(object)deleteTableColumnsItem1),
			new LinkPersistInfo((BarItem)(object)deleteTableRowsItem1),
			new LinkPersistInfo((BarItem)(object)deleteTableItem1)
		});
		((BarItem)deleteTableElementsItem1).Name = "deleteTableElementsItem1";
		((BarItem)showDeleteTableCellsFormItem1).Id = 75;
		((BarItem)showDeleteTableCellsFormItem1).Name = "showDeleteTableCellsFormItem1";
		((BarItem)deleteTableColumnsItem1).Id = 76;
		((BarItem)deleteTableColumnsItem1).Name = "deleteTableColumnsItem1";
		((BarItem)deleteTableRowsItem1).Id = 77;
		((BarItem)deleteTableRowsItem1).Name = "deleteTableRowsItem1";
		((BarItem)deleteTableItem1).Id = 78;
		((BarItem)deleteTableItem1).Name = "deleteTableItem1";
		((BarItem)insertTableRowAboveItem1).Id = 79;
		((BarItem)insertTableRowAboveItem1).Name = "insertTableRowAboveItem1";
		((BarItem)insertTableRowBelowItem1).Id = 80;
		((BarItem)insertTableRowBelowItem1).Name = "insertTableRowBelowItem1";
		((BarItem)insertTableColumnToLeftItem1).Id = 81;
		((BarItem)insertTableColumnToLeftItem1).Name = "insertTableColumnToLeftItem1";
		((BarItem)insertTableColumnToRightItem1).Id = 82;
		((BarItem)insertTableColumnToRightItem1).Name = "insertTableColumnToRightItem1";
		((BarItem)mergeTableCellsItem1).Id = 83;
		((BarItem)mergeTableCellsItem1).Name = "mergeTableCellsItem1";
		((BarItem)showSplitTableCellsForm1).Id = 84;
		((BarItem)showSplitTableCellsForm1).Name = "showSplitTableCellsForm1";
		((BarItem)splitTableItem1).Id = 85;
		((BarItem)splitTableItem1).Name = "splitTableItem1";
		((BarItem)toggleTableAutoFitItem1).Id = 86;
		((BarLinkContainerItem)toggleTableAutoFitItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[3]
		{
			new LinkPersistInfo((BarItem)(object)toggleTableAutoFitContentsItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableAutoFitWindowItem1),
			new LinkPersistInfo((BarItem)(object)toggleTableFixedColumnWidthItem1)
		});
		((BarItem)toggleTableAutoFitItem1).Name = "toggleTableAutoFitItem1";
		((BarItem)toggleTableAutoFitContentsItem1).Id = 87;
		((BarItem)toggleTableAutoFitContentsItem1).Name = "toggleTableAutoFitContentsItem1";
		((BarItem)toggleTableAutoFitWindowItem1).Id = 88;
		((BarItem)toggleTableAutoFitWindowItem1).Name = "toggleTableAutoFitWindowItem1";
		((BarItem)toggleTableFixedColumnWidthItem1).Id = 89;
		((BarItem)toggleTableFixedColumnWidthItem1).Name = "toggleTableFixedColumnWidthItem1";
		((BarItem)toggleTableCellsTopLeftAlignmentItem1).Id = 90;
		((BarItem)toggleTableCellsTopLeftAlignmentItem1).Name = "toggleTableCellsTopLeftAlignmentItem1";
		((BarItem)toggleTableCellsMiddleLeftAlignmentItem1).Id = 91;
		((BarItem)toggleTableCellsMiddleLeftAlignmentItem1).Name = "toggleTableCellsMiddleLeftAlignmentItem1";
		((BarItem)toggleTableCellsBottomLeftAlignmentItem1).Id = 92;
		((BarItem)toggleTableCellsBottomLeftAlignmentItem1).Name = "toggleTableCellsBottomLeftAlignmentItem1";
		((BarItem)toggleTableCellsTopCenterAlignmentItem1).Id = 93;
		((BarItem)toggleTableCellsTopCenterAlignmentItem1).Name = "toggleTableCellsTopCenterAlignmentItem1";
		((BarItem)toggleTableCellsMiddleCenterAlignmentItem1).Id = 94;
		((BarItem)toggleTableCellsMiddleCenterAlignmentItem1).Name = "toggleTableCellsMiddleCenterAlignmentItem1";
		((BarItem)toggleTableCellsBottomCenterAlignmentItem1).Id = 95;
		((BarItem)toggleTableCellsBottomCenterAlignmentItem1).Name = "toggleTableCellsBottomCenterAlignmentItem1";
		((BarItem)toggleTableCellsTopRightAlignmentItem1).Id = 96;
		((BarItem)toggleTableCellsTopRightAlignmentItem1).Name = "toggleTableCellsTopRightAlignmentItem1";
		((BarItem)toggleTableCellsMiddleRightAlignmentItem1).Id = 97;
		((BarItem)toggleTableCellsMiddleRightAlignmentItem1).Name = "toggleTableCellsMiddleRightAlignmentItem1";
		((BarItem)toggleTableCellsBottomRightAlignmentItem1).Id = 98;
		((BarItem)toggleTableCellsBottomRightAlignmentItem1).Name = "toggleTableCellsBottomRightAlignmentItem1";
		((BarItem)showTableOptionsFormItem1).Id = 99;
		((BarItem)showTableOptionsFormItem1).Name = "showTableOptionsFormItem1";
		((BarItem)undoItem1).Id = 100;
		((BarItem)undoItem1).Name = "undoItem1";
		((BarItem)redoItem1).Id = 101;
		((BarItem)redoItem1).Name = "redoItem1";
		((BarItem)quickPrintItem1).Id = 106;
		((BarItem)quickPrintItem1).Name = "quickPrintItem1";
		((BarItem)printItem1).Id = 107;
		((BarItem)printItem1).Name = "printItem1";
		((BarItem)printPreviewItem1).Id = 108;
		((BarItem)printPreviewItem1).Name = "printPreviewItem1";
		((BarItem)pasteItem1).Id = 116;
		((BarItem)pasteItem1).Name = "pasteItem1";
		((BarItem)cutItem1).Id = 117;
		((BarItem)cutItem1).Name = "cutItem1";
		((BarItem)copyItem1).Id = 118;
		((BarItem)copyItem1).Name = "copyItem1";
		((BarItem)pasteSpecialItem1).Id = 119;
		((BarItem)pasteSpecialItem1).Name = "pasteSpecialItem1";
		((BarItem)barButtonGroup1).Id = 109;
		((BarCustomContainerItem)barButtonGroup1).ItemLinks.Add((BarItem)(object)changeFontNameItem1);
		((BarCustomContainerItem)barButtonGroup1).ItemLinks.Add((BarItem)(object)changeFontSizeItem1);
		((BarCustomContainerItem)barButtonGroup1).ItemLinks.Add((BarItem)(object)fontSizeIncreaseItem1);
		((BarCustomContainerItem)barButtonGroup1).ItemLinks.Add((BarItem)(object)fontSizeDecreaseItem1);
		((BarItem)barButtonGroup1).Name = "barButtonGroup1";
		((BarItem)barButtonGroup1).Tag = "{97BBE334-159B-44d9-A168-0411957565E8}";
		((BarEditItem)changeFontNameItem1).Edit = (RepositoryItem)(object)repositoryItemFontEdit1;
		((BarItem)changeFontNameItem1).Id = 120;
		((BarItem)changeFontNameItem1).Name = "changeFontNameItem1";
		((RepositoryItem)repositoryItemFontEdit1).AutoHeight = false;
		((RepositoryItemButtonEdit)repositoryItemFontEdit1).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItem)repositoryItemFontEdit1).Name = "repositoryItemFontEdit1";
		((BarEditItem)changeFontSizeItem1).Edit = (RepositoryItem)(object)repositoryItemRichEditFontSizeEdit1;
		((BarItem)changeFontSizeItem1).Id = 121;
		((BarItem)changeFontSizeItem1).Name = "changeFontSizeItem1";
		((RepositoryItem)repositoryItemRichEditFontSizeEdit1).AutoHeight = false;
		((RepositoryItemButtonEdit)repositoryItemRichEditFontSizeEdit1).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		repositoryItemRichEditFontSizeEdit1.Control = rcDocumento;
		((RepositoryItem)repositoryItemRichEditFontSizeEdit1).Name = "repositoryItemRichEditFontSizeEdit1";
		((BarItem)fontSizeIncreaseItem1).Id = 122;
		((BarItem)fontSizeIncreaseItem1).Name = "fontSizeIncreaseItem1";
		((BarItem)fontSizeDecreaseItem1).Id = 123;
		((BarItem)fontSizeDecreaseItem1).Name = "fontSizeDecreaseItem1";
		((BarItem)barButtonGroup2).Id = 110;
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontBoldItem1);
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontItalicItem1);
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontUnderlineItem1);
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontDoubleUnderlineItem1);
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontStrikeoutItem1);
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontDoubleStrikeoutItem1);
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontSuperscriptItem1);
		((BarCustomContainerItem)barButtonGroup2).ItemLinks.Add((BarItem)(object)toggleFontSubscriptItem1);
		((BarItem)barButtonGroup2).Name = "barButtonGroup2";
		((BarItem)barButtonGroup2).Tag = "{433DA7F0-03E2-4650-9DB5-66DD92D16E39}";
		((BarItem)toggleFontBoldItem1).Id = 124;
		((BarItem)toggleFontBoldItem1).Name = "toggleFontBoldItem1";
		((BarItem)toggleFontItalicItem1).Id = 125;
		((BarItem)toggleFontItalicItem1).Name = "toggleFontItalicItem1";
		((BarItem)toggleFontUnderlineItem1).Id = 126;
		((BarItem)toggleFontUnderlineItem1).Name = "toggleFontUnderlineItem1";
		((BarItem)toggleFontDoubleUnderlineItem1).Id = 127;
		((BarItem)toggleFontDoubleUnderlineItem1).Name = "toggleFontDoubleUnderlineItem1";
		((BarItem)toggleFontStrikeoutItem1).Id = 128;
		((BarItem)toggleFontStrikeoutItem1).Name = "toggleFontStrikeoutItem1";
		((BarItem)toggleFontDoubleStrikeoutItem1).Id = 129;
		((BarItem)toggleFontDoubleStrikeoutItem1).Name = "toggleFontDoubleStrikeoutItem1";
		((BarItem)toggleFontSuperscriptItem1).Id = 130;
		((BarItem)toggleFontSuperscriptItem1).Name = "toggleFontSuperscriptItem1";
		((BarItem)toggleFontSubscriptItem1).Id = 131;
		((BarItem)toggleFontSubscriptItem1).Name = "toggleFontSubscriptItem1";
		((BarItem)barButtonGroup3).Id = 111;
		((BarCustomContainerItem)barButtonGroup3).ItemLinks.Add((BarItem)(object)changeFontColorItem1);
		((BarCustomContainerItem)barButtonGroup3).ItemLinks.Add((BarItem)(object)changeFontBackColorItem1);
		((BarItem)barButtonGroup3).Name = "barButtonGroup3";
		((BarItem)barButtonGroup3).Tag = "{DF8C5334-EDE3-47c9-A42C-FE9A9247E180}";
		((BarItem)changeFontColorItem1).Id = 132;
		((BarItem)changeFontColorItem1).Name = "changeFontColorItem1";
		((BarItem)changeFontBackColorItem1).Id = 133;
		((BarItem)changeFontBackColorItem1).Name = "changeFontBackColorItem1";
		((BarItem)changeTextCaseItem1).Id = 134;
		((BarLinkContainerItem)changeTextCaseItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[4]
		{
			new LinkPersistInfo((BarItem)(object)makeTextUpperCaseItem1),
			new LinkPersistInfo((BarItem)(object)makeTextLowerCaseItem1),
			new LinkPersistInfo((BarItem)(object)capitalizeEachWordCaseItem1),
			new LinkPersistInfo((BarItem)(object)toggleTextCaseItem1)
		});
		((BarItem)changeTextCaseItem1).Name = "changeTextCaseItem1";
		((BarItem)makeTextUpperCaseItem1).Id = 135;
		((BarItem)makeTextUpperCaseItem1).Name = "makeTextUpperCaseItem1";
		((BarItem)makeTextLowerCaseItem1).Id = 136;
		((BarItem)makeTextLowerCaseItem1).Name = "makeTextLowerCaseItem1";
		((BarItem)capitalizeEachWordCaseItem1).Id = 137;
		((BarItem)capitalizeEachWordCaseItem1).Name = "capitalizeEachWordCaseItem1";
		((BarItem)toggleTextCaseItem1).Id = 138;
		((BarItem)toggleTextCaseItem1).Name = "toggleTextCaseItem1";
		((BarItem)clearFormattingItem1).Id = 139;
		((BarItem)clearFormattingItem1).Name = "clearFormattingItem1";
		((BarItem)barButtonGroup4).Id = 112;
		((BarCustomContainerItem)barButtonGroup4).ItemLinks.Add((BarItem)(object)toggleBulletedListItem1);
		((BarCustomContainerItem)barButtonGroup4).ItemLinks.Add((BarItem)(object)toggleNumberingListItem1);
		((BarCustomContainerItem)barButtonGroup4).ItemLinks.Add((BarItem)(object)toggleMultiLevelListItem1);
		((BarItem)barButtonGroup4).Name = "barButtonGroup4";
		((BarItem)barButtonGroup4).Tag = "{0B3A7A43-3079-4ce0-83A8-3789F5F6DC9F}";
		((BarItem)toggleBulletedListItem1).Id = 140;
		((BarItem)toggleBulletedListItem1).Name = "toggleBulletedListItem1";
		((BarItem)toggleNumberingListItem1).Id = 141;
		((BarItem)toggleNumberingListItem1).Name = "toggleNumberingListItem1";
		((BarItem)toggleMultiLevelListItem1).Id = 142;
		((BarItem)toggleMultiLevelListItem1).Name = "toggleMultiLevelListItem1";
		((BarItem)barButtonGroup5).Id = 113;
		((BarCustomContainerItem)barButtonGroup5).ItemLinks.Add((BarItem)(object)decreaseIndentItem1);
		((BarCustomContainerItem)barButtonGroup5).ItemLinks.Add((BarItem)(object)increaseIndentItem1);
		((BarCustomContainerItem)barButtonGroup5).ItemLinks.Add((BarItem)(object)toggleShowWhitespaceItem1);
		((BarItem)barButtonGroup5).Name = "barButtonGroup5";
		((BarItem)barButtonGroup5).Tag = "{4747D5AB-2BEB-4ea6-9A1D-8E4FB36F1B40}";
		((BarItem)decreaseIndentItem1).Id = 143;
		((BarItem)decreaseIndentItem1).Name = "decreaseIndentItem1";
		((BarItem)increaseIndentItem1).Id = 144;
		((BarItem)increaseIndentItem1).Name = "increaseIndentItem1";
		((BarItem)toggleShowWhitespaceItem1).Id = 149;
		((BarItem)toggleShowWhitespaceItem1).Name = "toggleShowWhitespaceItem1";
		((BarItem)barButtonGroup6).Id = 114;
		((BarCustomContainerItem)barButtonGroup6).ItemLinks.Add((BarItem)(object)toggleParagraphAlignmentLeftItem1);
		((BarCustomContainerItem)barButtonGroup6).ItemLinks.Add((BarItem)(object)toggleParagraphAlignmentCenterItem1);
		((BarCustomContainerItem)barButtonGroup6).ItemLinks.Add((BarItem)(object)toggleParagraphAlignmentRightItem1);
		((BarCustomContainerItem)barButtonGroup6).ItemLinks.Add((BarItem)(object)toggleParagraphAlignmentJustifyItem1);
		((BarItem)barButtonGroup6).Name = "barButtonGroup6";
		((BarItem)barButtonGroup6).Tag = "{8E89E775-996E-49a0-AADA-DE338E34732E}";
		((BarItem)toggleParagraphAlignmentLeftItem1).Id = 145;
		((BarItem)toggleParagraphAlignmentLeftItem1).Name = "toggleParagraphAlignmentLeftItem1";
		((BarItem)toggleParagraphAlignmentCenterItem1).Id = 146;
		((BarItem)toggleParagraphAlignmentCenterItem1).Name = "toggleParagraphAlignmentCenterItem1";
		((BarItem)toggleParagraphAlignmentRightItem1).Id = 147;
		((BarItem)toggleParagraphAlignmentRightItem1).Name = "toggleParagraphAlignmentRightItem1";
		((BarItem)toggleParagraphAlignmentJustifyItem1).Id = 148;
		((BarItem)toggleParagraphAlignmentJustifyItem1).Name = "toggleParagraphAlignmentJustifyItem1";
		((BarItem)barButtonGroup7).Id = 115;
		((BarCustomContainerItem)barButtonGroup7).ItemLinks.Add((BarItem)(object)changeParagraphLineSpacingItem1);
		((BarCustomContainerItem)barButtonGroup7).ItemLinks.Add((BarItem)(object)changeParagraphBackColorItem1);
		((BarItem)barButtonGroup7).Name = "barButtonGroup7";
		((BarItem)barButtonGroup7).Tag = "{9A8DEAD8-3890-4857-A395-EC625FD02217}";
		((BarItem)changeParagraphLineSpacingItem1).Id = 150;
		((BarLinkContainerItem)changeParagraphLineSpacingItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[8]
		{
			new LinkPersistInfo((BarItem)(object)setSingleParagraphSpacingItem1),
			new LinkPersistInfo((BarItem)(object)setSesquialteralParagraphSpacingItem1),
			new LinkPersistInfo((BarItem)(object)setDoubleParagraphSpacingItem1),
			new LinkPersistInfo((BarItem)(object)showLineSpacingFormItem1),
			new LinkPersistInfo((BarItem)(object)addSpacingBeforeParagraphItem1),
			new LinkPersistInfo((BarItem)(object)removeSpacingBeforeParagraphItem1),
			new LinkPersistInfo((BarItem)(object)addSpacingAfterParagraphItem1),
			new LinkPersistInfo((BarItem)(object)removeSpacingAfterParagraphItem1)
		});
		((BarItem)changeParagraphLineSpacingItem1).Name = "changeParagraphLineSpacingItem1";
		((BarItem)setSingleParagraphSpacingItem1).Id = 151;
		((BarItem)setSingleParagraphSpacingItem1).Name = "setSingleParagraphSpacingItem1";
		((BarItem)setSesquialteralParagraphSpacingItem1).Id = 152;
		((BarItem)setSesquialteralParagraphSpacingItem1).Name = "setSesquialteralParagraphSpacingItem1";
		((BarItem)setDoubleParagraphSpacingItem1).Id = 153;
		((BarItem)setDoubleParagraphSpacingItem1).Name = "setDoubleParagraphSpacingItem1";
		((BarItem)showLineSpacingFormItem1).Id = 154;
		((BarItem)showLineSpacingFormItem1).Name = "showLineSpacingFormItem1";
		((BarItem)addSpacingBeforeParagraphItem1).Id = 155;
		((BarItem)addSpacingBeforeParagraphItem1).Name = "addSpacingBeforeParagraphItem1";
		((BarItem)removeSpacingBeforeParagraphItem1).Id = 156;
		((BarItem)removeSpacingBeforeParagraphItem1).Name = "removeSpacingBeforeParagraphItem1";
		((BarItem)addSpacingAfterParagraphItem1).Id = 157;
		((BarItem)addSpacingAfterParagraphItem1).Name = "addSpacingAfterParagraphItem1";
		((BarItem)removeSpacingAfterParagraphItem1).Id = 158;
		((BarItem)removeSpacingAfterParagraphItem1).Name = "removeSpacingAfterParagraphItem1";
		((BarItem)changeParagraphBackColorItem1).Id = 159;
		((BarItem)changeParagraphBackColorItem1).Name = "changeParagraphBackColorItem1";
		((BarItem)findItem1).Id = 161;
		((BarItem)findItem1).Name = "findItem1";
		((BarItem)replaceItem1).Id = 162;
		((BarItem)replaceItem1).Name = "replaceItem1";
		((BarItem)insertPageBreakItem21).Id = 163;
		((BarItem)insertPageBreakItem21).Name = "insertPageBreakItem21";
		((BarItem)insertTableItem1).Id = 164;
		((BarItem)insertTableItem1).Name = "insertTableItem1";
		((BarItem)insertPictureItem1).Id = 165;
		((BarItem)insertPictureItem1).Name = "insertPictureItem1";
		((BarItem)insertFloatingPictureItem1).Id = 166;
		((BarItem)insertFloatingPictureItem1).Name = "insertFloatingPictureItem1";
		((BarItem)insertBookmarkItem1).Id = 167;
		((BarItem)insertBookmarkItem1).Name = "insertBookmarkItem1";
		((BarItem)insertHyperlinkItem1).Id = 168;
		((BarItem)insertHyperlinkItem1).Name = "insertHyperlinkItem1";
		((BarItem)editPageHeaderItem1).Id = 169;
		((BarItem)editPageHeaderItem1).Name = "editPageHeaderItem1";
		((BarItem)editPageFooterItem1).Id = 170;
		((BarItem)editPageFooterItem1).Name = "editPageFooterItem1";
		((BarItem)insertPageNumberItem1).Id = 171;
		((BarItem)insertPageNumberItem1).Name = "insertPageNumberItem1";
		((BarItem)insertPageCountItem1).Id = 172;
		((BarItem)insertPageCountItem1).Name = "insertPageCountItem1";
		((BarItem)insertTextBoxItem1).Id = 173;
		((BarItem)insertTextBoxItem1).Name = "insertTextBoxItem1";
		((BarItem)insertSymbolItem1).Id = 174;
		((BarItem)insertSymbolItem1).Name = "insertSymbolItem1";
		((BarItem)insertTableOfContentsItem1).Id = 175;
		((BarItem)insertTableOfContentsItem1).Name = "insertTableOfContentsItem1";
		((BarItem)updateTableOfContentsItem1).Id = 176;
		((BarItem)updateTableOfContentsItem1).Name = "updateTableOfContentsItem1";
		((BarItem)addParagraphsToTableOfContentItem1).Id = 177;
		((BarLinkContainerItem)addParagraphsToTableOfContentItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[10]
		{
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem1),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem2),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem3),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem4),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem5),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem6),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem7),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem8),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem9),
			new LinkPersistInfo((BarItem)(object)setParagraphHeadingLevelItem10)
		});
		((BarItem)addParagraphsToTableOfContentItem1).Name = "addParagraphsToTableOfContentItem1";
		((BarItem)setParagraphHeadingLevelItem1).Id = 178;
		((BarItem)setParagraphHeadingLevelItem1).Name = "setParagraphHeadingLevelItem1";
		setParagraphHeadingLevelItem1.OutlineLevel = 0;
		((BarItem)setParagraphHeadingLevelItem2).Id = 179;
		((BarItem)setParagraphHeadingLevelItem2).Name = "setParagraphHeadingLevelItem2";
		setParagraphHeadingLevelItem2.OutlineLevel = 1;
		((BarItem)setParagraphHeadingLevelItem3).Id = 180;
		((BarItem)setParagraphHeadingLevelItem3).Name = "setParagraphHeadingLevelItem3";
		setParagraphHeadingLevelItem3.OutlineLevel = 2;
		((BarItem)setParagraphHeadingLevelItem4).Id = 181;
		((BarItem)setParagraphHeadingLevelItem4).Name = "setParagraphHeadingLevelItem4";
		setParagraphHeadingLevelItem4.OutlineLevel = 3;
		((BarItem)setParagraphHeadingLevelItem5).Id = 182;
		((BarItem)setParagraphHeadingLevelItem5).Name = "setParagraphHeadingLevelItem5";
		setParagraphHeadingLevelItem5.OutlineLevel = 4;
		((BarItem)setParagraphHeadingLevelItem6).Id = 183;
		((BarItem)setParagraphHeadingLevelItem6).Name = "setParagraphHeadingLevelItem6";
		setParagraphHeadingLevelItem6.OutlineLevel = 5;
		((BarItem)setParagraphHeadingLevelItem7).Id = 184;
		((BarItem)setParagraphHeadingLevelItem7).Name = "setParagraphHeadingLevelItem7";
		setParagraphHeadingLevelItem7.OutlineLevel = 6;
		((BarItem)setParagraphHeadingLevelItem8).Id = 185;
		((BarItem)setParagraphHeadingLevelItem8).Name = "setParagraphHeadingLevelItem8";
		setParagraphHeadingLevelItem8.OutlineLevel = 7;
		((BarItem)setParagraphHeadingLevelItem9).Id = 186;
		((BarItem)setParagraphHeadingLevelItem9).Name = "setParagraphHeadingLevelItem9";
		setParagraphHeadingLevelItem9.OutlineLevel = 8;
		((BarItem)setParagraphHeadingLevelItem10).Id = 187;
		((BarItem)setParagraphHeadingLevelItem10).Name = "setParagraphHeadingLevelItem10";
		setParagraphHeadingLevelItem10.OutlineLevel = 9;
		((BarItem)insertCaptionPlaceholderItem1).Id = 188;
		((BarLinkContainerItem)insertCaptionPlaceholderItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[3]
		{
			new LinkPersistInfo((BarItem)(object)insertFiguresCaptionItems1),
			new LinkPersistInfo((BarItem)(object)insertTablesCaptionItems1),
			new LinkPersistInfo((BarItem)(object)insertEquationsCaptionItems1)
		});
		((BarItem)insertCaptionPlaceholderItem1).Name = "insertCaptionPlaceholderItem1";
		((BarItem)insertFiguresCaptionItems1).Id = 189;
		((BarItem)insertFiguresCaptionItems1).Name = "insertFiguresCaptionItems1";
		((BarItem)insertTablesCaptionItems1).Id = 190;
		((BarItem)insertTablesCaptionItems1).Name = "insertTablesCaptionItems1";
		((BarItem)insertEquationsCaptionItems1).Id = 191;
		((BarItem)insertEquationsCaptionItems1).Name = "insertEquationsCaptionItems1";
		((BarItem)insertTableOfFiguresPlaceholderItem1).Id = 192;
		((BarLinkContainerItem)insertTableOfFiguresPlaceholderItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[3]
		{
			new LinkPersistInfo((BarItem)(object)insertTableOfFiguresItems1),
			new LinkPersistInfo((BarItem)(object)insertTableOfTablesItems1),
			new LinkPersistInfo((BarItem)(object)insertTableOfEquationsItems1)
		});
		((BarItem)insertTableOfFiguresPlaceholderItem1).Name = "insertTableOfFiguresPlaceholderItem1";
		((BarItem)insertTableOfFiguresItems1).Id = 193;
		((BarItem)insertTableOfFiguresItems1).Name = "insertTableOfFiguresItems1";
		((BarItem)insertTableOfTablesItems1).Id = 194;
		((BarItem)insertTableOfTablesItems1).Name = "insertTableOfTablesItems1";
		((BarItem)insertTableOfEquationsItems1).Id = 195;
		((BarItem)insertTableOfEquationsItems1).Name = "insertTableOfEquationsItems1";
		((BarItem)updateTableOfFiguresItem1).Id = 196;
		((BarItem)updateTableOfFiguresItem1).Name = "updateTableOfFiguresItem1";
		((BarItem)checkSpellingItem1).Id = 201;
		((BarItem)checkSpellingItem1).Name = "checkSpellingItem1";
		((BarItem)changeLanguageItem1).Id = 202;
		((BarItem)changeLanguageItem1).Name = "changeLanguageItem1";
		((BarItem)protectDocumentItem1).Id = 203;
		((BarItem)protectDocumentItem1).Name = "protectDocumentItem1";
		((BarItem)changeRangeEditingPermissionsItem1).Id = 204;
		((BarItem)changeRangeEditingPermissionsItem1).Name = "changeRangeEditingPermissionsItem1";
		((BarItem)unprotectDocumentItem1).Id = 205;
		((BarItem)unprotectDocumentItem1).Name = "unprotectDocumentItem1";
		((BarItem)changeCommentItem1).Id = 206;
		((BarItem)changeCommentItem1).Name = "changeCommentItem1";
		((BarItem)reviewersItem1).Id = 207;
		((BarItem)reviewersItem1).Name = "reviewersItem1";
		((BarItem)reviewingPaneItem1).Id = 208;
		((BarItem)reviewingPaneItem1).Name = "reviewingPaneItem1";
		((BarItem)changeFloatingObjectFillColorItem1).Id = 209;
		((BarItem)changeFloatingObjectFillColorItem1).Name = "changeFloatingObjectFillColorItem1";
		((BarItem)changeFloatingObjectOutlineColorItem1).Id = 210;
		((BarItem)changeFloatingObjectOutlineColorItem1).Name = "changeFloatingObjectOutlineColorItem1";
		((BarEditItem)changeFloatingObjectOutlineWeightItem1).Edit = (RepositoryItem)(object)repositoryItemFloatingObjectOutlineWeight1;
		((BarEditItem)changeFloatingObjectOutlineWeightItem1).EditValue = 20;
		((BarItem)changeFloatingObjectOutlineWeightItem1).Id = 211;
		((BarItem)changeFloatingObjectOutlineWeightItem1).Name = "changeFloatingObjectOutlineWeightItem1";
		((RepositoryItem)repositoryItemFloatingObjectOutlineWeight1).AutoHeight = false;
		((RepositoryItemButtonEdit)repositoryItemFloatingObjectOutlineWeight1).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItemBorderLineWeight)repositoryItemFloatingObjectOutlineWeight1).Control = rcDocumento;
		((RepositoryItem)repositoryItemFloatingObjectOutlineWeight1).Name = "repositoryItemFloatingObjectOutlineWeight1";
		((BarItem)changeFloatingObjectTextWrapTypeItem1).Id = 212;
		((BarLinkContainerItem)changeFloatingObjectTextWrapTypeItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[6]
		{
			new LinkPersistInfo((BarItem)(object)setFloatingObjectSquareTextWrapTypeItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectTightTextWrapTypeItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectThroughTextWrapTypeItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectTopAndBottomTextWrapTypeItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectBehindTextWrapTypeItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectInFrontOfTextWrapTypeItem1)
		});
		((BarItem)changeFloatingObjectTextWrapTypeItem1).Name = "changeFloatingObjectTextWrapTypeItem1";
		((BarItem)setFloatingObjectSquareTextWrapTypeItem1).Id = 213;
		((BarItem)setFloatingObjectSquareTextWrapTypeItem1).Name = "setFloatingObjectSquareTextWrapTypeItem1";
		((BarItem)setFloatingObjectTightTextWrapTypeItem1).Id = 214;
		((BarItem)setFloatingObjectTightTextWrapTypeItem1).Name = "setFloatingObjectTightTextWrapTypeItem1";
		((BarItem)setFloatingObjectThroughTextWrapTypeItem1).Id = 215;
		((BarItem)setFloatingObjectThroughTextWrapTypeItem1).Name = "setFloatingObjectThroughTextWrapTypeItem1";
		((BarItem)setFloatingObjectTopAndBottomTextWrapTypeItem1).Id = 216;
		((BarItem)setFloatingObjectTopAndBottomTextWrapTypeItem1).Name = "setFloatingObjectTopAndBottomTextWrapTypeItem1";
		((BarItem)setFloatingObjectBehindTextWrapTypeItem1).Id = 217;
		((BarItem)setFloatingObjectBehindTextWrapTypeItem1).Name = "setFloatingObjectBehindTextWrapTypeItem1";
		((BarItem)setFloatingObjectInFrontOfTextWrapTypeItem1).Id = 218;
		((BarItem)setFloatingObjectInFrontOfTextWrapTypeItem1).Name = "setFloatingObjectInFrontOfTextWrapTypeItem1";
		((BarItem)changeFloatingObjectAlignmentItem1).Id = 219;
		((BarLinkContainerItem)changeFloatingObjectAlignmentItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[9]
		{
			new LinkPersistInfo((BarItem)(object)setFloatingObjectTopLeftAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectTopCenterAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectTopRightAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectMiddleLeftAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectMiddleCenterAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectMiddleRightAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectBottomLeftAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectBottomCenterAlignmentItem1),
			new LinkPersistInfo((BarItem)(object)setFloatingObjectBottomRightAlignmentItem1)
		});
		((BarItem)changeFloatingObjectAlignmentItem1).Name = "changeFloatingObjectAlignmentItem1";
		((BarItem)setFloatingObjectTopLeftAlignmentItem1).Id = 220;
		((BarItem)setFloatingObjectTopLeftAlignmentItem1).Name = "setFloatingObjectTopLeftAlignmentItem1";
		((BarItem)setFloatingObjectTopCenterAlignmentItem1).Id = 221;
		((BarItem)setFloatingObjectTopCenterAlignmentItem1).Name = "setFloatingObjectTopCenterAlignmentItem1";
		((BarItem)setFloatingObjectTopRightAlignmentItem1).Id = 222;
		((BarItem)setFloatingObjectTopRightAlignmentItem1).Name = "setFloatingObjectTopRightAlignmentItem1";
		((BarItem)setFloatingObjectMiddleLeftAlignmentItem1).Id = 223;
		((BarItem)setFloatingObjectMiddleLeftAlignmentItem1).Name = "setFloatingObjectMiddleLeftAlignmentItem1";
		((BarItem)setFloatingObjectMiddleCenterAlignmentItem1).Id = 224;
		((BarItem)setFloatingObjectMiddleCenterAlignmentItem1).Name = "setFloatingObjectMiddleCenterAlignmentItem1";
		((BarItem)setFloatingObjectMiddleRightAlignmentItem1).Id = 225;
		((BarItem)setFloatingObjectMiddleRightAlignmentItem1).Name = "setFloatingObjectMiddleRightAlignmentItem1";
		((BarItem)setFloatingObjectBottomLeftAlignmentItem1).Id = 226;
		((BarItem)setFloatingObjectBottomLeftAlignmentItem1).Name = "setFloatingObjectBottomLeftAlignmentItem1";
		((BarItem)setFloatingObjectBottomCenterAlignmentItem1).Id = 227;
		((BarItem)setFloatingObjectBottomCenterAlignmentItem1).Name = "setFloatingObjectBottomCenterAlignmentItem1";
		((BarItem)setFloatingObjectBottomRightAlignmentItem1).Id = 228;
		((BarItem)setFloatingObjectBottomRightAlignmentItem1).Name = "setFloatingObjectBottomRightAlignmentItem1";
		((BarItem)floatingObjectBringForwardSubItem1).Id = 229;
		((BarLinkContainerItem)floatingObjectBringForwardSubItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[3]
		{
			new LinkPersistInfo((BarItem)(object)floatingObjectBringForwardItem1),
			new LinkPersistInfo((BarItem)(object)floatingObjectBringToFrontItem1),
			new LinkPersistInfo((BarItem)(object)floatingObjectBringInFrontOfTextItem1)
		});
		((BarItem)floatingObjectBringForwardSubItem1).Name = "floatingObjectBringForwardSubItem1";
		((BarItem)floatingObjectBringForwardItem1).Id = 230;
		((BarItem)floatingObjectBringForwardItem1).Name = "floatingObjectBringForwardItem1";
		((BarItem)floatingObjectBringToFrontItem1).Id = 231;
		((BarItem)floatingObjectBringToFrontItem1).Name = "floatingObjectBringToFrontItem1";
		((BarItem)floatingObjectBringInFrontOfTextItem1).Id = 232;
		((BarItem)floatingObjectBringInFrontOfTextItem1).Name = "floatingObjectBringInFrontOfTextItem1";
		((BarItem)floatingObjectSendBackwardSubItem1).Id = 233;
		((BarLinkContainerItem)floatingObjectSendBackwardSubItem1).LinksPersistInfo.AddRange((LinkPersistInfo[])(object)new LinkPersistInfo[3]
		{
			new LinkPersistInfo((BarItem)(object)floatingObjectSendBackwardItem1),
			new LinkPersistInfo((BarItem)(object)floatingObjectSendToBackItem1),
			new LinkPersistInfo((BarItem)(object)floatingObjectSendBehindTextItem1)
		});
		((BarItem)floatingObjectSendBackwardSubItem1).Name = "floatingObjectSendBackwardSubItem1";
		((BarItem)floatingObjectSendBackwardItem1).Id = 234;
		((BarItem)floatingObjectSendBackwardItem1).Name = "floatingObjectSendBackwardItem1";
		((BarItem)floatingObjectSendToBackItem1).Id = 235;
		((BarItem)floatingObjectSendToBackItem1).Name = "floatingObjectSendToBackItem1";
		((BarItem)floatingObjectSendBehindTextItem1).Id = 236;
		((BarItem)floatingObjectSendBehindTextItem1).Name = "floatingObjectSendBehindTextItem1";
		((RibbonPageCategory)headerFooterToolsRibbonPageCategory1).Color = Color.FromArgb(38, 176, 35);
		((ControlCommandBasedRibbonPageCategory<RichEditControl, RichEditCommandId>)(object)headerFooterToolsRibbonPageCategory1).Control = rcDocumento;
		((RibbonPageCategory)headerFooterToolsRibbonPageCategory1).Name = "headerFooterToolsRibbonPageCategory1";
		((RibbonPageCategory)headerFooterToolsRibbonPageCategory1).Pages.AddRange((RibbonPage[])(object)new RibbonPage[1] { (RibbonPage)headerFooterToolsDesignRibbonPage1 });
		((RibbonPage)headerFooterToolsDesignRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[3]
		{
			(RibbonPageGroup)headerFooterToolsDesignNavigationRibbonPageGroup1,
			(RibbonPageGroup)headerFooterToolsDesignOptionsRibbonPageGroup1,
			(RibbonPageGroup)headerFooterToolsDesignCloseRibbonPageGroup1
		});
		((RibbonPage)headerFooterToolsDesignRibbonPage1).Name = "headerFooterToolsDesignRibbonPage1";
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignNavigationRibbonPageGroup1).ItemLinks).Add((BarItem)(object)goToPageHeaderItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignNavigationRibbonPageGroup1).ItemLinks).Add((BarItem)(object)goToPageFooterItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignNavigationRibbonPageGroup1).ItemLinks).Add((BarItem)(object)goToNextHeaderFooterItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignNavigationRibbonPageGroup1).ItemLinks).Add((BarItem)(object)goToPreviousHeaderFooterItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignNavigationRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleLinkToPreviousItem1);
		((RibbonPageGroup)headerFooterToolsDesignNavigationRibbonPageGroup1).Name = "headerFooterToolsDesignNavigationRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleDifferentFirstPageItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleDifferentOddAndEvenPagesItem1);
		((RibbonPageGroup)headerFooterToolsDesignOptionsRibbonPageGroup1).Name = "headerFooterToolsDesignOptionsRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterToolsDesignCloseRibbonPageGroup1).ItemLinks).Add((BarItem)(object)closePageHeaderFooterItem1);
		((RibbonPageGroup)headerFooterToolsDesignCloseRibbonPageGroup1).Name = "headerFooterToolsDesignCloseRibbonPageGroup1";
		((RibbonPageCategory)tableToolsRibbonPageCategory1).Color = Color.FromArgb(252, 233, 20);
		((ControlCommandBasedRibbonPageCategory<RichEditControl, RichEditCommandId>)(object)tableToolsRibbonPageCategory1).Control = rcDocumento;
		((RibbonPageCategory)tableToolsRibbonPageCategory1).Name = "tableToolsRibbonPageCategory1";
		((RibbonPageCategory)tableToolsRibbonPageCategory1).Pages.AddRange((RibbonPage[])(object)new RibbonPage[2]
		{
			(RibbonPage)tableDesignRibbonPage1,
			(RibbonPage)tableLayoutRibbonPage1
		});
		((RibbonPage)tableDesignRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[3]
		{
			(RibbonPageGroup)tableStyleOptionsRibbonPageGroup1,
			(RibbonPageGroup)tableStylesRibbonPageGroup1,
			(RibbonPageGroup)tableDrawBordersRibbonPageGroup1
		});
		((RibbonPage)tableDesignRibbonPage1).Name = "tableDesignRibbonPage1";
		((BarItemLinkCollection)((RibbonPageGroup)tableStyleOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleFirstRowItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableStyleOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleLastRowItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableStyleOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleBandedRowsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableStyleOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleFirstColumnItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableStyleOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleLastColumnItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableStyleOptionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleBandedColumnsItem1);
		((RibbonPageGroup)tableStyleOptionsRibbonPageGroup1).Name = "tableStyleOptionsRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)tableStylesRibbonPageGroup1).ItemLinks).Add((BarItem)(object)galleryChangeTableStyleItem1);
		((RibbonPageGroup)tableStylesRibbonPageGroup1).Name = "tableStylesRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)tableDrawBordersRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeTableBorderLineStyleItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableDrawBordersRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeTableBorderLineWeightItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableDrawBordersRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeTableBorderColorItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableDrawBordersRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeTableBordersItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableDrawBordersRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeTableCellsShadingItem1);
		((RibbonPageGroup)tableDrawBordersRibbonPageGroup1).Name = "tableDrawBordersRibbonPageGroup1";
		((RibbonPage)tableLayoutRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[5]
		{
			(RibbonPageGroup)tableTableRibbonPageGroup1,
			(RibbonPageGroup)tableRowsAndColumnsRibbonPageGroup1,
			(RibbonPageGroup)tableMergeRibbonPageGroup1,
			(RibbonPageGroup)tableCellSizeRibbonPageGroup1,
			(RibbonPageGroup)tableAlignmentRibbonPageGroup1
		});
		((RibbonPage)tableLayoutRibbonPage1).Name = "tableLayoutRibbonPage1";
		((BarItemLinkCollection)((RibbonPageGroup)tableTableRibbonPageGroup1).ItemLinks).Add((BarItem)(object)selectTableElementsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableTableRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleShowTableGridLinesItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableTableRibbonPageGroup1).ItemLinks).Add((BarItem)(object)showTablePropertiesFormItem1);
		((RibbonPageGroup)tableTableRibbonPageGroup1).Name = "tableTableRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)tableRowsAndColumnsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)deleteTableElementsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableRowsAndColumnsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTableRowAboveItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableRowsAndColumnsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTableRowBelowItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableRowsAndColumnsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTableColumnToLeftItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableRowsAndColumnsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTableColumnToRightItem1);
		((RibbonPageGroup)tableRowsAndColumnsRibbonPageGroup1).Name = "tableRowsAndColumnsRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)tableMergeRibbonPageGroup1).ItemLinks).Add((BarItem)(object)mergeTableCellsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableMergeRibbonPageGroup1).ItemLinks).Add((BarItem)(object)showSplitTableCellsForm1);
		((BarItemLinkCollection)((RibbonPageGroup)tableMergeRibbonPageGroup1).ItemLinks).Add((BarItem)(object)splitTableItem1);
		((RibbonPageGroup)tableMergeRibbonPageGroup1).Name = "tableMergeRibbonPageGroup1";
		((RibbonPageGroup)tableCellSizeRibbonPageGroup1).AllowTextClipping = false;
		((BarItemLinkCollection)((RibbonPageGroup)tableCellSizeRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableAutoFitItem1);
		((RibbonPageGroup)tableCellSizeRibbonPageGroup1).Name = "tableCellSizeRibbonPageGroup1";
		((RibbonPageGroup)tableAlignmentRibbonPageGroup1).Glyph = (Image)componentResourceManager.GetObject("tableAlignmentRibbonPageGroup1.Glyph");
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsTopLeftAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsMiddleLeftAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsBottomLeftAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsTopCenterAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsMiddleCenterAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsBottomCenterAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsTopRightAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsMiddleRightAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleTableCellsBottomRightAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableAlignmentRibbonPageGroup1).ItemLinks).Add((BarItem)(object)showTableOptionsFormItem1);
		((RibbonPageGroup)tableAlignmentRibbonPageGroup1).Name = "tableAlignmentRibbonPageGroup1";
		((RibbonPageCategory)floatingPictureToolsRibbonPageCategory1).Color = Color.FromArgb(201, 0, 119);
		((ControlCommandBasedRibbonPageCategory<RichEditControl, RichEditCommandId>)(object)floatingPictureToolsRibbonPageCategory1).Control = rcDocumento;
		((RibbonPageCategory)floatingPictureToolsRibbonPageCategory1).Name = "floatingPictureToolsRibbonPageCategory1";
		((RibbonPageCategory)floatingPictureToolsRibbonPageCategory1).Pages.AddRange((RibbonPage[])(object)new RibbonPage[1] { (RibbonPage)floatingPictureToolsFormatPage1 });
		((RibbonPage)floatingPictureToolsFormatPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[2]
		{
			(RibbonPageGroup)floatingPictureToolsShapeStylesPageGroup1,
			(RibbonPageGroup)floatingPictureToolsArrangePageGroup1
		});
		((RibbonPage)floatingPictureToolsFormatPage1).Name = "floatingPictureToolsFormatPage1";
		((BarItemLinkCollection)((RibbonPageGroup)floatingPictureToolsShapeStylesPageGroup1).ItemLinks).Add((BarItem)(object)changeFloatingObjectFillColorItem1);
		((BarItemLinkCollection)((RibbonPageGroup)floatingPictureToolsShapeStylesPageGroup1).ItemLinks).Add((BarItem)(object)changeFloatingObjectOutlineColorItem1);
		((BarItemLinkCollection)((RibbonPageGroup)floatingPictureToolsShapeStylesPageGroup1).ItemLinks).Add((BarItem)(object)changeFloatingObjectOutlineWeightItem1);
		((RibbonPageGroup)floatingPictureToolsShapeStylesPageGroup1).Name = "floatingPictureToolsShapeStylesPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)floatingPictureToolsArrangePageGroup1).ItemLinks).Add((BarItem)(object)changeFloatingObjectTextWrapTypeItem1);
		((BarItemLinkCollection)((RibbonPageGroup)floatingPictureToolsArrangePageGroup1).ItemLinks).Add((BarItem)(object)changeFloatingObjectAlignmentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)floatingPictureToolsArrangePageGroup1).ItemLinks).Add((BarItem)(object)floatingObjectBringForwardSubItem1);
		((BarItemLinkCollection)((RibbonPageGroup)floatingPictureToolsArrangePageGroup1).ItemLinks).Add((BarItem)(object)floatingObjectSendBackwardSubItem1);
		((RibbonPageGroup)floatingPictureToolsArrangePageGroup1).Name = "floatingPictureToolsArrangePageGroup1";
		((RibbonPage)homeRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[5]
		{
			(RibbonPageGroup)clipboardRibbonPageGroup1,
			(RibbonPageGroup)fontRibbonPageGroup1,
			(RibbonPageGroup)paragraphRibbonPageGroup1,
			(RibbonPageGroup)stylesRibbonPageGroup1,
			(RibbonPageGroup)editingRibbonPageGroup1
		});
		((RibbonPage)homeRibbonPage1).Name = "homeRibbonPage1";
		val4.Behavior = (ReduceOperationBehavior)1;
		val4.Group = (RibbonPageGroup)(object)stylesRibbonPageGroup1;
		val4.ItemLinkIndex = 0;
		val4.ItemLinksCount = 0;
		val4.Operation = (ReduceOperationType)0;
		((RibbonPage)homeRibbonPage1).ReduceOperations.Add(val4);
		((BarItemLinkCollection)((RibbonPageGroup)clipboardRibbonPageGroup1).ItemLinks).Add((BarItem)(object)pasteItem1);
		((BarItemLinkCollection)((RibbonPageGroup)clipboardRibbonPageGroup1).ItemLinks).Add((BarItem)(object)cutItem1);
		((BarItemLinkCollection)((RibbonPageGroup)clipboardRibbonPageGroup1).ItemLinks).Add((BarItem)(object)copyItem1);
		((BarItemLinkCollection)((RibbonPageGroup)clipboardRibbonPageGroup1).ItemLinks).Add((BarItem)(object)pasteSpecialItem1);
		((RibbonPageGroup)clipboardRibbonPageGroup1).Name = "clipboardRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)fontRibbonPageGroup1).ItemLinks).Add((BarItem)(object)barButtonGroup1);
		((BarItemLinkCollection)((RibbonPageGroup)fontRibbonPageGroup1).ItemLinks).Add((BarItem)(object)barButtonGroup2);
		((BarItemLinkCollection)((RibbonPageGroup)fontRibbonPageGroup1).ItemLinks).Add((BarItem)(object)barButtonGroup3);
		((BarItemLinkCollection)((RibbonPageGroup)fontRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeTextCaseItem1);
		((BarItemLinkCollection)((RibbonPageGroup)fontRibbonPageGroup1).ItemLinks).Add((BarItem)(object)clearFormattingItem1);
		((RibbonPageGroup)fontRibbonPageGroup1).Name = "fontRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)paragraphRibbonPageGroup1).ItemLinks).Add((BarItem)(object)barButtonGroup4);
		((BarItemLinkCollection)((RibbonPageGroup)paragraphRibbonPageGroup1).ItemLinks).Add((BarItem)(object)barButtonGroup5);
		((BarItemLinkCollection)((RibbonPageGroup)paragraphRibbonPageGroup1).ItemLinks).Add((BarItem)(object)barButtonGroup6);
		((BarItemLinkCollection)((RibbonPageGroup)paragraphRibbonPageGroup1).ItemLinks).Add((BarItem)(object)barButtonGroup7);
		((RibbonPageGroup)paragraphRibbonPageGroup1).Name = "paragraphRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)editingRibbonPageGroup1).ItemLinks).Add((BarItem)(object)findItem1);
		((BarItemLinkCollection)((RibbonPageGroup)editingRibbonPageGroup1).ItemLinks).Add((BarItem)(object)replaceItem1);
		((RibbonPageGroup)editingRibbonPageGroup1).Name = "editingRibbonPageGroup1";
		((RibbonPage)pageLayoutRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[2]
		{
			(RibbonPageGroup)pageSetupRibbonPageGroup1,
			(RibbonPageGroup)pageBackgroundRibbonPageGroup1
		});
		((RibbonPage)pageLayoutRibbonPage1).Name = "pageLayoutRibbonPage1";
		((BarItemLinkCollection)((RibbonPageGroup)pageSetupRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeSectionPageMarginsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)pageSetupRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeSectionPageOrientationItem1);
		((BarItemLinkCollection)((RibbonPageGroup)pageSetupRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeSectionPaperKindItem1);
		((BarItemLinkCollection)((RibbonPageGroup)pageSetupRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeSectionColumnsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)pageSetupRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertBreakItem1);
		((BarItemLinkCollection)((RibbonPageGroup)pageSetupRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeSectionLineNumberingItem1);
		((RibbonPageGroup)pageSetupRibbonPageGroup1).Name = "pageSetupRibbonPageGroup1";
		((RibbonPageGroup)pageBackgroundRibbonPageGroup1).AllowTextClipping = false;
		((BarItemLinkCollection)((RibbonPageGroup)pageBackgroundRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changePageColorItem1);
		((RibbonPageGroup)pageBackgroundRibbonPageGroup1).Name = "pageBackgroundRibbonPageGroup1";
		((RibbonPage)viewRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[3]
		{
			(RibbonPageGroup)documentViewsRibbonPageGroup1,
			(RibbonPageGroup)showRibbonPageGroup1,
			(RibbonPageGroup)zoomRibbonPageGroup1
		});
		((RibbonPage)viewRibbonPage1).Name = "viewRibbonPage1";
		((BarItemLinkCollection)((RibbonPageGroup)documentViewsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)switchToSimpleViewItem1);
		((BarItemLinkCollection)((RibbonPageGroup)documentViewsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)switchToDraftViewItem1);
		((BarItemLinkCollection)((RibbonPageGroup)documentViewsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)switchToPrintLayoutViewItem1);
		((RibbonPageGroup)documentViewsRibbonPageGroup1).Name = "documentViewsRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)showRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleShowHorizontalRulerItem1);
		((BarItemLinkCollection)((RibbonPageGroup)showRibbonPageGroup1).ItemLinks).Add((BarItem)(object)toggleShowVerticalRulerItem1);
		((RibbonPageGroup)showRibbonPageGroup1).Name = "showRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)zoomRibbonPageGroup1).ItemLinks).Add((BarItem)(object)zoomOutItem1);
		((BarItemLinkCollection)((RibbonPageGroup)zoomRibbonPageGroup1).ItemLinks).Add((BarItem)(object)zoomInItem1);
		((RibbonPageGroup)zoomRibbonPageGroup1).Name = "zoomRibbonPageGroup1";
		((RibbonPage)insertRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[7]
		{
			(RibbonPageGroup)pagesRibbonPageGroup1,
			(RibbonPageGroup)tablesRibbonPageGroup1,
			(RibbonPageGroup)illustrationsRibbonPageGroup1,
			(RibbonPageGroup)linksRibbonPageGroup1,
			(RibbonPageGroup)headerFooterRibbonPageGroup1,
			(RibbonPageGroup)textRibbonPageGroup1,
			(RibbonPageGroup)symbolsRibbonPageGroup1
		});
		((RibbonPage)insertRibbonPage1).Name = "insertRibbonPage1";
		((RibbonPageGroup)pagesRibbonPageGroup1).AllowTextClipping = false;
		((BarItemLinkCollection)((RibbonPageGroup)pagesRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertPageBreakItem21);
		((RibbonPageGroup)pagesRibbonPageGroup1).Name = "pagesRibbonPageGroup1";
		((RibbonPageGroup)tablesRibbonPageGroup1).AllowTextClipping = false;
		((BarItemLinkCollection)((RibbonPageGroup)tablesRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTableItem1);
		((RibbonPageGroup)tablesRibbonPageGroup1).Name = "tablesRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)illustrationsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertPictureItem1);
		((BarItemLinkCollection)((RibbonPageGroup)illustrationsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertFloatingPictureItem1);
		((RibbonPageGroup)illustrationsRibbonPageGroup1).Name = "illustrationsRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)linksRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertBookmarkItem1);
		((BarItemLinkCollection)((RibbonPageGroup)linksRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertHyperlinkItem1);
		((RibbonPageGroup)linksRibbonPageGroup1).Name = "linksRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterRibbonPageGroup1).ItemLinks).Add((BarItem)(object)editPageHeaderItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterRibbonPageGroup1).ItemLinks).Add((BarItem)(object)editPageFooterItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertPageNumberItem1);
		((BarItemLinkCollection)((RibbonPageGroup)headerFooterRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertPageCountItem1);
		((RibbonPageGroup)headerFooterRibbonPageGroup1).Name = "headerFooterRibbonPageGroup1";
		((RibbonPageGroup)textRibbonPageGroup1).Glyph = (Image)componentResourceManager.GetObject("textRibbonPageGroup1.Glyph");
		((BarItemLinkCollection)((RibbonPageGroup)textRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTextBoxItem1);
		((RibbonPageGroup)textRibbonPageGroup1).Name = "textRibbonPageGroup1";
		((RibbonPageGroup)symbolsRibbonPageGroup1).AllowTextClipping = false;
		((BarItemLinkCollection)((RibbonPageGroup)symbolsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertSymbolItem1);
		((RibbonPageGroup)symbolsRibbonPageGroup1).Name = "symbolsRibbonPageGroup1";
		((RibbonPage)referencesRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[2]
		{
			(RibbonPageGroup)tableOfContentsRibbonPageGroup1,
			(RibbonPageGroup)captionsRibbonPageGroup1
		});
		((RibbonPage)referencesRibbonPage1).Name = "referencesRibbonPage1";
		((BarItemLinkCollection)((RibbonPageGroup)tableOfContentsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTableOfContentsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableOfContentsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)updateTableOfContentsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)tableOfContentsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)addParagraphsToTableOfContentItem1);
		((RibbonPageGroup)tableOfContentsRibbonPageGroup1).Name = "tableOfContentsRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)captionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertCaptionPlaceholderItem1);
		((BarItemLinkCollection)((RibbonPageGroup)captionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)insertTableOfFiguresPlaceholderItem1);
		((BarItemLinkCollection)((RibbonPageGroup)captionsRibbonPageGroup1).ItemLinks).Add((BarItem)(object)updateTableOfFiguresItem1);
		((RibbonPageGroup)captionsRibbonPageGroup1).Name = "captionsRibbonPageGroup1";
		((RibbonPage)reviewRibbonPage1).Groups.AddRange((RibbonPageGroup[])(object)new RibbonPageGroup[3]
		{
			(RibbonPageGroup)documentProofingRibbonPageGroup1,
			(RibbonPageGroup)documentProtectionRibbonPageGroup1,
			(RibbonPageGroup)documentTrackingRibbonPageGroup1
		});
		((RibbonPage)reviewRibbonPage1).Name = "reviewRibbonPage1";
		((BarItemLinkCollection)((RibbonPageGroup)documentProofingRibbonPageGroup1).ItemLinks).Add((BarItem)(object)checkSpellingItem1);
		((BarItemLinkCollection)((RibbonPageGroup)documentProofingRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeLanguageItem1);
		((RibbonPageGroup)documentProofingRibbonPageGroup1).Name = "documentProofingRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)documentProtectionRibbonPageGroup1).ItemLinks).Add((BarItem)(object)protectDocumentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)documentProtectionRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeRangeEditingPermissionsItem1);
		((BarItemLinkCollection)((RibbonPageGroup)documentProtectionRibbonPageGroup1).ItemLinks).Add((BarItem)(object)unprotectDocumentItem1);
		((RibbonPageGroup)documentProtectionRibbonPageGroup1).Name = "documentProtectionRibbonPageGroup1";
		((BarItemLinkCollection)((RibbonPageGroup)documentTrackingRibbonPageGroup1).ItemLinks).Add((BarItem)(object)changeCommentItem1);
		((BarItemLinkCollection)((RibbonPageGroup)documentTrackingRibbonPageGroup1).ItemLinks).Add((BarItem)(object)reviewersItem1);
		((BarItemLinkCollection)((RibbonPageGroup)documentTrackingRibbonPageGroup1).ItemLinks).Add((BarItem)(object)reviewingPaneItem1);
		((RibbonPageGroup)documentTrackingRibbonPageGroup1).Name = "documentTrackingRibbonPageGroup1";
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeSectionPageMarginsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setNormalSectionPageMarginsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setNarrowSectionPageMarginsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setModerateSectionPageMarginsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setWideSectionPageMarginsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showPageMarginsSetupFormItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeSectionPageOrientationItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setPortraitPageOrientationItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setLandscapePageOrientationItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeSectionPaperKindItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeSectionColumnsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSectionOneColumnItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSectionTwoColumnsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSectionThreeColumnsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showColumnsSetupFormItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertBreakItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertPageBreakItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertColumnBreakItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertSectionBreakNextPageItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertSectionBreakEvenPageItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertSectionBreakOddPageItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeSectionLineNumberingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSectionLineNumberingNoneItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSectionLineNumberingContinuousItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSectionLineNumberingRestartNewPageItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSectionLineNumberingRestartNewSectionItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleParagraphSuppressLineNumbersItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showLineNumberingFormItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changePageColorItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)switchToSimpleViewItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)switchToDraftViewItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)switchToPrintLayoutViewItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleShowHorizontalRulerItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleShowVerticalRulerItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)zoomOutItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)zoomInItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)goToPageHeaderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)goToPageFooterItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)goToNextHeaderFooterItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)goToPreviousHeaderFooterItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleLinkToPreviousItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleDifferentFirstPageItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleDifferentOddAndEvenPagesItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)closePageHeaderFooterItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFirstRowItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleLastRowItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleBandedRowsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFirstColumnItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleLastColumnItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleBandedColumnsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)galleryChangeTableStyleItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeTableBorderLineStyleItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeTableBorderLineWeightItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeTableBorderColorItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeTableBordersItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsBottomBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsTopBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsLeftBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsRightBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)resetTableCellsAllBordersItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsAllBordersItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsOutsideBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsInsideBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsInsideHorizontalBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsInsideVerticalBorderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleShowTableGridLinesItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeTableCellsShadingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)selectTableElementsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)selectTableCellItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)selectTableColumnItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)selectTableRowItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)selectTableItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showTablePropertiesFormItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)deleteTableElementsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showDeleteTableCellsFormItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)deleteTableColumnsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)deleteTableRowsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)deleteTableItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableRowAboveItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableRowBelowItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableColumnToLeftItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableColumnToRightItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)mergeTableCellsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showSplitTableCellsForm1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)splitTableItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableAutoFitItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableAutoFitContentsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableAutoFitWindowItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableFixedColumnWidthItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsTopLeftAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsMiddleLeftAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsBottomLeftAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsTopCenterAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsMiddleCenterAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsBottomCenterAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsTopRightAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsMiddleRightAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTableCellsBottomRightAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showTableOptionsFormItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)undoItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)redoItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)quickPrintItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)printItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)printPreviewItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)pasteItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)cutItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)copyItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)pasteSpecialItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFontNameItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFontSizeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)fontSizeIncreaseItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)fontSizeDecreaseItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontBoldItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontItalicItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontUnderlineItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontDoubleUnderlineItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontStrikeoutItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontDoubleStrikeoutItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontSuperscriptItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleFontSubscriptItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFontColorItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFontBackColorItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeTextCaseItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)makeTextUpperCaseItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)makeTextLowerCaseItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)capitalizeEachWordCaseItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleTextCaseItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)clearFormattingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleBulletedListItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleNumberingListItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleMultiLevelListItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)decreaseIndentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)increaseIndentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleParagraphAlignmentLeftItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleParagraphAlignmentCenterItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleParagraphAlignmentRightItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleParagraphAlignmentJustifyItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)toggleShowWhitespaceItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeParagraphLineSpacingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSingleParagraphSpacingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setSesquialteralParagraphSpacingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setDoubleParagraphSpacingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)showLineSpacingFormItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)addSpacingBeforeParagraphItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)removeSpacingBeforeParagraphItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)addSpacingAfterParagraphItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)removeSpacingAfterParagraphItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeParagraphBackColorItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)galleryChangeStyleItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)findItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)replaceItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertPageBreakItem21);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertPictureItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertFloatingPictureItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertBookmarkItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertHyperlinkItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)editPageHeaderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)editPageFooterItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertPageNumberItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertPageCountItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTextBoxItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertSymbolItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableOfContentsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)updateTableOfContentsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)addParagraphsToTableOfContentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem2);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem3);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem4);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem5);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem6);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem7);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem8);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem9);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setParagraphHeadingLevelItem10);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertCaptionPlaceholderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertFiguresCaptionItems1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTablesCaptionItems1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertEquationsCaptionItems1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableOfFiguresPlaceholderItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableOfFiguresItems1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableOfTablesItems1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)insertTableOfEquationsItems1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)updateTableOfFiguresItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)checkSpellingItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeLanguageItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)protectDocumentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeRangeEditingPermissionsItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)unprotectDocumentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeCommentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)reviewersItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)reviewingPaneItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFloatingObjectFillColorItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFloatingObjectOutlineColorItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFloatingObjectOutlineWeightItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFloatingObjectTextWrapTypeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectSquareTextWrapTypeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectTightTextWrapTypeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectThroughTextWrapTypeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectTopAndBottomTextWrapTypeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectBehindTextWrapTypeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectInFrontOfTextWrapTypeItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)changeFloatingObjectAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectTopLeftAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectTopCenterAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectTopRightAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectMiddleLeftAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectMiddleCenterAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectMiddleRightAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectBottomLeftAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectBottomCenterAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)setFloatingObjectBottomRightAlignmentItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectBringForwardSubItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectBringForwardItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectBringToFrontItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectBringInFrontOfTextItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectSendBackwardSubItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectSendBackwardItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectSendToBackItem1);
		((CommandBarController)richEditBarController1).BarItems.Add((BarItem)(object)floatingObjectSendBehindTextItem1);
		((ControlCommandBarControllerBase<RichEditControl, RichEditCommandId>)(object)richEditBarController1).Control = rcDocumento;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
		((Control)this).Controls.Add((Control)(object)rcDocumento);
		((Control)this).Controls.Add((Control)(object)ribbonControl1);
		((Control)this).Name = "ucWord";
		((Control)this).Size = new Size(787, 551);
		((ISupportInitialize)ribbonControl1).EndInit();
		((ISupportInitialize)repositoryItemBorderLineStyle1).EndInit();
		((ISupportInitialize)repositoryItemBorderLineWeight1).EndInit();
		((ISupportInitialize)repositoryItemFontEdit1).EndInit();
		((ISupportInitialize)repositoryItemRichEditFontSizeEdit1).EndInit();
		((ISupportInitialize)repositoryItemFloatingObjectOutlineWeight1).EndInit();
		((ISupportInitialize)richEditBarController1).EndInit();
		((Control)this).ResumeLayout(performLayout: false);
		((Control)this).PerformLayout();
	}
}
