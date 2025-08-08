using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using MaxTek.MaxEditors.Windows.Forms;

namespace MaxTek.ERP.BLL;

public class frmCadastrarCambio : MaxFormBase
{
	private decimal valor = default(decimal);

	private IContainer components = null;

	private SpinEdit txValorTaxa;

	private LabelControl labelControl1;

	private Button btnCadastrar;

	private Button btnCancelar;

	public decimal Valor
	{
		get
		{
			return valor;
		}
		set
		{
			if (!(valor == value))
			{
				valor = value;
			}
		}
	}

	public frmCadastrarCambio()
	{
		InitializeComponent();
	}

	private void txValorTaxa_EditValueChanged(object sender, EventArgs e)
	{
		valor = txValorTaxa.Value;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		txValorTaxa = new SpinEdit();
		labelControl1 = new LabelControl();
		btnCancelar = new Button();
		btnCadastrar = new Button();
		((ISupportInitialize)txValorTaxa.Properties).BeginInit();
		((XtraForm)this).SuspendLayout();
		((BaseEdit)txValorTaxa).EditValue = new decimal(new int[4]);
		((Control)(object)txValorTaxa).Location = new Point(12, 32);
		((Control)(object)txValorTaxa).Name = "txValorTaxa";
		((RepositoryItem)txValorTaxa.Properties).Appearance.Font = new Font("Tahoma", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((RepositoryItem)txValorTaxa.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)txValorTaxa.Properties).AutoHeight = false;
		((RepositoryItemButtonEdit)txValorTaxa.Properties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton()
		});
		((Control)(object)txValorTaxa).Size = new Size(253, 57);
		((Control)(object)txValorTaxa).TabIndex = 0;
		((BaseEdit)txValorTaxa).EditValueChanged += txValorTaxa_EditValueChanged;
		((AppearanceObject)labelControl1.Appearance).Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		((Control)(object)labelControl1).Location = new Point(38, 7);
		((Control)(object)labelControl1).Name = "labelControl1";
		((Control)(object)labelControl1).Size = new Size(201, 19);
		((Control)(object)labelControl1).TabIndex = 1;
		((Control)(object)labelControl1).Text = "Digite a Taxa de Câmbio";
		btnCancelar.DialogResult = DialogResult.Cancel;
		btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
		btnCancelar.Location = new Point(174, 95);
		btnCancelar.Name = "btnCancelar";
		btnCancelar.Size = new Size(91, 23);
		btnCancelar.TabIndex = 3;
		btnCancelar.Text = "Cancelar";
		btnCancelar.UseVisualStyleBackColor = true;
		btnCadastrar.DialogResult = DialogResult.OK;
		btnCadastrar.ImageAlign = ContentAlignment.MiddleLeft;
		btnCadastrar.Location = new Point(12, 95);
		btnCadastrar.Name = "btnCadastrar";
		btnCadastrar.Size = new Size(98, 23);
		btnCadastrar.TabIndex = 2;
		btnCadastrar.Text = "Cadastrar";
		btnCadastrar.UseVisualStyleBackColor = true;
		((Form)(object)this).AcceptButton = btnCadastrar;
		((Form)(object)this).CancelButton = btnCancelar;
		((Form)(object)this).ClientSize = new Size(277, 125);
		((Form)(object)this).ControlBox = false;
		((Control)(object)this).Controls.Add(btnCancelar);
		((Control)(object)this).Controls.Add(btnCadastrar);
		((Control)(object)this).Controls.Add((Control)(object)labelControl1);
		((Control)(object)this).Controls.Add((Control)(object)txValorTaxa);
		((Form)(object)this).FormBorderStyle = FormBorderStyle.None;
		((Control)(object)this).Name = "frmCadastrarCambio";
		((Form)(object)this).StartPosition = FormStartPosition.CenterParent;
		((Form)(object)this).TopMost = true;
		((ISupportInitialize)txValorTaxa.Properties).EndInit();
		((XtraForm)this).ResumeLayout(false);
		((Control)(object)this).PerformLayout();
	}
}
