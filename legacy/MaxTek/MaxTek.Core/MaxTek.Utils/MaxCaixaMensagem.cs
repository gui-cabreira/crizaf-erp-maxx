using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaxTek.Utils;

public static class MaxCaixaMensagem
{
	public static DialogResult ShowAtencaoOK(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowAtencaoOK(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowAtencaoOKCancela(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowAtencaoOKCancela(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowAtencaoSimNao(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowAtencaoSimNao(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowAtencaoSimNao(IWin32Window onwer, string mensagem, string titulo)
	{
		return XtraMessageBox.Show(onwer, mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowAtencaoSimNao(IWin32Window onwer, string mensagem)
	{
		return XtraMessageBox.Show(onwer, mensagem, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
	}

	public static DialogResult ShowPergunta(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}

	public static DialogResult ShowPergunta(IWin32Window onwer, string mensagem, string titulo)
	{
		return XtraMessageBox.Show(onwer, mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}

	public static DialogResult ShowPergunta(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}

	public static DialogResult ShowPergunta(IWin32Window onwer, string mensagem)
	{
		return XtraMessageBox.Show(onwer, mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}

	public static DialogResult ShowInformacao(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	public static DialogResult ShowInformacao(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	public static DialogResult ShowErroOK(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public static DialogResult ShowErroOK(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public static DialogResult ShowErroOKCancela(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
	}

	public static DialogResult ShowErroOKCancela(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
	}

	public static DialogResult ShowErroSimNao(string mensagem, string titulo)
	{
		return XtraMessageBox.Show(mensagem, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
	}

	public static DialogResult ShowErroSimNao(string mensagem)
	{
		return XtraMessageBox.Show(mensagem, "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
	}
}
