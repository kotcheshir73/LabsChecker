using LabsChecker.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace LabsChecker.Forms;

public partial class LabWorkConfigForm : Form
{
	public LabWorkConfigForm(IServiceProvider service)
	{
		InitializeComponent();
		var labWorkConfigControl = service.GetRequiredService<LabWorkConfigControl>();
		labWorkConfigControl.Dock = DockStyle.Fill;
		labWorkConfigControl.Location = new Point(0, 0);
		labWorkConfigControl.Name = "labWorkConfigControl";
		labWorkConfigControl.Size = new Size(100, 100);
		labWorkConfigControl.TabIndex = 0;

		Controls.Add(labWorkConfigControl);
	}
}