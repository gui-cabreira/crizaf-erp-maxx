using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MaxTek.Core.Design;

public class BindablePropertyEditor : Form
{
	private BindingList<BindableProperty> _bindableProperties;

	private Type _tipoDataSource;

	private IContainer components = null;

	private TreeView treeView1;

	private ListView listView1;

	private Button btnRemover;

	private Button btnAdicionar;

	private ImageList imageList1;

	private Button btnOk;

	private Button btnCancelar;

	private ColumnHeader columnHeader1;

	private Label label1;

	private Label label2;

	private Button btnAdicionarTodos;

	private Button btnRemoverTodos;

	public BindingList<BindableProperty> BindableProperties
	{
		get
		{
			return _bindableProperties;
		}
		set
		{
			if (_bindableProperties == null)
			{
				_bindableProperties = new BindingList<BindableProperty>();
			}
			foreach (BindableProperty item in value)
			{
				_bindableProperties.Add(new BindableProperty(item.Name, ""));
			}
		}
	}

	public Type TipoDataSource
	{
		get
		{
			return _tipoDataSource;
		}
		set
		{
			_tipoDataSource = value;
		}
	}

	public BindablePropertyEditor()
	{
		InitializeComponent();
		_bindableProperties = null;
	}

	private void BindablePropertyEditor_Load(object sender, EventArgs e)
	{
		if (TipoDataSource != null)
		{
			TreeNode treeNode = AdicionarTNodePai(TipoDataSource);
			treeNode.StateImageIndex = 2;
			CarregarPropriedades(TipoDataSource, treeNode);
			treeNode.Expand();
			CarregarBindableProperties();
		}
		else
		{
			btnAdicionar.Enabled = false;
			btnRemover.Enabled = false;
		}
	}

	public static bool Execute(BindingList<BindableProperty> bindableProperties, Type tipoDataSource)
	{
		BindablePropertyEditor bindablePropertyEditor = new BindablePropertyEditor();
		bindablePropertyEditor.BindableProperties = bindableProperties;
		bindablePropertyEditor.TipoDataSource = tipoDataSource;
		bool flag = bindablePropertyEditor.ShowDialog() == DialogResult.OK;
		if (flag)
		{
			bindableProperties.Clear();
			foreach (BindableProperty bindableProperty in bindablePropertyEditor.BindableProperties)
			{
				bindableProperties.Add(bindableProperty);
			}
		}
		return flag;
	}

	private TreeNode AdicionarTNodePai(Type tipo)
	{
		treeView1.BeginUpdate();
		TreeNode treeNode = treeView1.Nodes.Add(tipo.FullName);
		treeView1.EndUpdate();
		treeNode.StateImageIndex = 0;
		return treeNode;
	}

	private void CarregarPropriedades(Type tipo, TreeNode nodePai)
	{
		PropertyInfo[] properties = tipo.GetProperties();
		treeView1.BeginUpdate();
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			Type propertyType = propertyInfo.PropertyType;
			if (!Attribute.IsDefined(propertyInfo, typeof(NotBindable)))
			{
				PropertyInfo[] array2 = null;
				if (propertyType.IsClass && propertyType != typeof(string) && propertyType != typeof(Image))
				{
					array2 = propertyType.GetProperties();
				}
				TreeNode treeNode = new TreeNode(propertyInfo.Name);
				treeNode.ToolTipText = propertyType.ToString();
				if (array2 != null && array2.Length != 0)
				{
					treeNode.StateImageIndex = 0;
					treeNode.Nodes.Add("");
					treeNode.Tag = propertyType;
				}
				else
				{
					treeNode.StateImageIndex = 1;
				}
				nodePai.Nodes.Add(treeNode);
			}
		}
		treeView1.EndUpdate();
	}

	private string ObterNomeNode(TreeNode node)
	{
		string text = string.Empty;
		if (node.Parent != null && node.Parent.Level != 0)
		{
			text = ObterNomeNode(node.Parent);
		}
		string empty = string.Empty;
		if (!string.IsNullOrEmpty(text))
		{
			return text + "." + node.Text;
		}
		return node.Text;
	}

	private void AdicionarItem()
	{
		TreeNode selectedNode = treeView1.SelectedNode;
		if (selectedNode.Nodes.Count == 0)
		{
			string text = ObterNomeNode(selectedNode);
			if (!ExistePropriedade(text))
			{
				ListViewItem listViewItem = listView1.Items.Add(text);
				listViewItem.StateImageIndex = 3;
				BindableProperties.Add(new BindableProperty(listViewItem.Text, listViewItem.Text.Replace(".", "_")));
			}
			else
			{
				MessageBox.Show("O valor " + text + ", já está na lista.", Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void AdicionarTodosItens()
	{
		foreach (TreeNode node in treeView1.Nodes[0].Nodes)
		{
			if (node.Nodes.Count == 0)
			{
				string propriedade = ObterNomeNode(node);
				if (!ExistePropriedade(propriedade))
				{
					ListViewItem listViewItem = listView1.Items.Add(propriedade);
					listViewItem.StateImageIndex = 3;
					BindableProperties.Add(new BindableProperty(listViewItem.Text, listViewItem.Text.Replace(".", "_")));
				}
			}
		}
	}

	private bool ExistePropriedade(string propriedade)
	{
		bool result = false;
		foreach (BindableProperty bindableProperty in BindableProperties)
		{
			if (bindableProperty.Name == propriedade)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private void RemoverItem()
	{
		foreach (ListViewItem selectedItem in listView1.SelectedItems)
		{
			listView1.Items.Remove(selectedItem);
			int index = -1;
			for (int i = 0; i < BindableProperties.Count; i++)
			{
				if (BindableProperties[i].Name == selectedItem.Text)
				{
					index = i;
					break;
				}
			}
			BindableProperties.RemoveAt(index);
		}
	}

	private void RemoverTodosItens()
	{
		foreach (ListViewItem item in listView1.Items)
		{
			listView1.Items.Remove(item);
			int index = -1;
			for (int i = 0; i < BindableProperties.Count; i++)
			{
				if (BindableProperties[i].Name == item.Text)
				{
					index = i;
					break;
				}
			}
			BindableProperties.RemoveAt(index);
		}
	}

	private void CarregarBindableProperties()
	{
		if (BindableProperties == null)
		{
			return;
		}
		foreach (BindableProperty bindableProperty in BindableProperties)
		{
			ListViewItem listViewItem = listView1.Items.Add(bindableProperty.Name);
			listViewItem.StateImageIndex = 3;
		}
	}

	private void btnAdicionar_Click(object sender, EventArgs e)
	{
		AdicionarItem();
	}

	private void btnRemover_Click(object sender, EventArgs e)
	{
		RemoverItem();
	}

	private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
	{
		if (e.Node.Tag != null && e.Node.Nodes[0].Text.Length == 0)
		{
			e.Node.Nodes.Clear();
			Type tipo = (Type)e.Node.Tag;
			CarregarPropriedades(tipo, e.Node);
		}
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnCancelar_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		AdicionarItem();
	}

	private void btnAdicionarTodos_Click(object sender, EventArgs e)
	{
		AdicionarTodosItens();
	}

	private void btnRemoverTodos_Click(object sender, EventArgs e)
	{
		RemoverTodosItens();
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaxTek.Core.Design.BindablePropertyEditor));
		this.treeView1 = new System.Windows.Forms.TreeView();
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader1 = new System.Windows.Forms.ColumnHeader("(none)");
		this.btnRemover = new System.Windows.Forms.Button();
		this.btnAdicionar = new System.Windows.Forms.Button();
		this.btnOk = new System.Windows.Forms.Button();
		this.btnCancelar = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.btnAdicionarTodos = new System.Windows.Forms.Button();
		this.btnRemoverTodos = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.treeView1.CausesValidation = false;
		this.treeView1.Location = new System.Drawing.Point(12, 25);
		this.treeView1.Name = "treeView1";
		this.treeView1.ShowNodeToolTips = true;
		this.treeView1.Size = new System.Drawing.Size(293, 311);
		this.treeView1.StateImageList = this.imageList1;
		this.treeView1.TabIndex = 3;
		this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(treeView1_NodeMouseDoubleClick);
		this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(treeView1_BeforeExpand);
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
		this.imageList1.Images.SetKeyName(0, "MaxManufacturing.ico");
		this.imageList1.Images.SetKeyName(1, "text.png");
		this.imageList1.Images.SetKeyName(2, "class.bmp");
		this.imageList1.Images.SetKeyName(3, "text_ok.png");
		this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1] { this.columnHeader1 });
		this.listView1.Location = new System.Drawing.Point(332, 25);
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(293, 352);
		this.listView1.StateImageList = this.imageList1;
		this.listView1.TabIndex = 6;
		this.listView1.TileSize = new System.Drawing.Size(300, 12);
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.columnHeader1.Text = "";
		this.columnHeader1.Width = 299;
		this.btnRemover.Location = new System.Drawing.Point(170, 354);
		this.btnRemover.Name = "btnRemover";
		this.btnRemover.Size = new System.Drawing.Size(135, 23);
		this.btnRemover.TabIndex = 9;
		this.btnRemover.Text = "Remover";
		this.btnRemover.UseVisualStyleBackColor = true;
		this.btnRemover.Click += new System.EventHandler(btnRemover_Click);
		this.btnAdicionar.Location = new System.Drawing.Point(12, 354);
		this.btnAdicionar.Name = "btnAdicionar";
		this.btnAdicionar.Size = new System.Drawing.Size(135, 23);
		this.btnAdicionar.TabIndex = 8;
		this.btnAdicionar.Text = "Adicionar";
		this.btnAdicionar.UseVisualStyleBackColor = true;
		this.btnAdicionar.Click += new System.EventHandler(btnAdicionar_Click);
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.Location = new System.Drawing.Point(332, 392);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(135, 23);
		this.btnOk.TabIndex = 10;
		this.btnOk.Text = "OK";
		this.btnOk.UseVisualStyleBackColor = true;
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancelar.Location = new System.Drawing.Point(490, 392);
		this.btnCancelar.Name = "btnCancelar";
		this.btnCancelar.Size = new System.Drawing.Size(135, 23);
		this.btnCancelar.TabIndex = 11;
		this.btnCancelar.Text = "Cancelar";
		this.btnCancelar.UseVisualStyleBackColor = true;
		this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(9, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(103, 13);
		this.label1.TabIndex = 12;
		this.label1.Text = "Objetos a selecionar";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(329, 9);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(134, 13);
		this.label2.TabIndex = 13;
		this.label2.Text = "Propriedades selecionadas";
		this.btnAdicionarTodos.Location = new System.Drawing.Point(12, 383);
		this.btnAdicionarTodos.Name = "btnAdicionarTodos";
		this.btnAdicionarTodos.Size = new System.Drawing.Size(135, 23);
		this.btnAdicionarTodos.TabIndex = 14;
		this.btnAdicionarTodos.Text = "Adicionar Todos";
		this.btnAdicionarTodos.UseVisualStyleBackColor = true;
		this.btnAdicionarTodos.Click += new System.EventHandler(btnAdicionarTodos_Click);
		this.btnRemoverTodos.Location = new System.Drawing.Point(170, 383);
		this.btnRemoverTodos.Name = "btnRemoverTodos";
		this.btnRemoverTodos.Size = new System.Drawing.Size(135, 23);
		this.btnRemoverTodos.TabIndex = 15;
		this.btnRemoverTodos.Text = "Remover Todos";
		this.btnRemoverTodos.UseVisualStyleBackColor = true;
		this.btnRemoverTodos.Click += new System.EventHandler(btnRemoverTodos_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(637, 440);
		base.Controls.Add(this.btnRemoverTodos);
		base.Controls.Add(this.btnAdicionarTodos);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btnCancelar);
		base.Controls.Add(this.btnOk);
		base.Controls.Add(this.btnRemover);
		base.Controls.Add(this.btnAdicionar);
		base.Controls.Add(this.listView1);
		base.Controls.Add(this.treeView1);
		base.Name = "BindablePropertyEditor";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "BindablePropertyEditor";
		base.Load += new System.EventHandler(BindablePropertyEditor_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
