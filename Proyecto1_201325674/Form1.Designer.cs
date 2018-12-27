namespace Proyecto1_201325674
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarArchivoConfiguracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarArchivoDeCargaEscenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarJuegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeSimbolosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTecnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombrePersonaje = new System.Windows.Forms.Label();
            this.lblVidaPersonaje = new System.Windows.Forms.Label();
            this.panelSelectFondos = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectOTroFondo = new System.Windows.Forms.Button();
            this.pictureBoxFondoSelect = new System.Windows.Forms.PictureBox();
            this.btnFondoSiguiente = new System.Windows.Forms.Button();
            this.btnFondoAnterior = new System.Windows.Forms.Button();
            this.panelSelectPersonaje = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.BtnSeleccionarOtroPersonaje = new System.Windows.Forms.Button();
            this.vidaPersonajeSelect = new System.Windows.Forms.Label();
            this.NombrePersonajeSelect = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.lblPerdida = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelEscenario = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panelSelectFondos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondoSelect)).BeginInit();
            this.panelSelectPersonaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(951, 453);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(228, 100);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ejecutarToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1171, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarArchivoConfiguracionToolStripMenuItem,
            this.compilarArchivoDeCargaEscenarioToolStripMenuItem,
            this.ejecutarJuegoToolStripMenuItem,
            this.erroresToolStripMenuItem,
            this.tablaDeSimbolosToolStripMenuItem});
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ejecutarToolStripMenuItem.Text = "Ejecutar";
            // 
            // ejecutarArchivoConfiguracionToolStripMenuItem
            // 
            this.ejecutarArchivoConfiguracionToolStripMenuItem.Name = "ejecutarArchivoConfiguracionToolStripMenuItem";
            this.ejecutarArchivoConfiguracionToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.ejecutarArchivoConfiguracionToolStripMenuItem.Text = "Compilar archivo configuracion";
            this.ejecutarArchivoConfiguracionToolStripMenuItem.Click += new System.EventHandler(this.ejecutarArchivoConfiguracionToolStripMenuItem_Click);
            // 
            // compilarArchivoDeCargaEscenarioToolStripMenuItem
            // 
            this.compilarArchivoDeCargaEscenarioToolStripMenuItem.Name = "compilarArchivoDeCargaEscenarioToolStripMenuItem";
            this.compilarArchivoDeCargaEscenarioToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.compilarArchivoDeCargaEscenarioToolStripMenuItem.Text = "Compilar archivo de carga escenario";
            this.compilarArchivoDeCargaEscenarioToolStripMenuItem.Click += new System.EventHandler(this.compilarArchivoDeCargaEscenarioToolStripMenuItem_Click);
            // 
            // ejecutarJuegoToolStripMenuItem
            // 
            this.ejecutarJuegoToolStripMenuItem.Name = "ejecutarJuegoToolStripMenuItem";
            this.ejecutarJuegoToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.ejecutarJuegoToolStripMenuItem.Text = "Ejecutar juego";
            this.ejecutarJuegoToolStripMenuItem.Click += new System.EventHandler(this.ejecutarJuegoToolStripMenuItem_Click_1);
            // 
            // erroresToolStripMenuItem
            // 
            this.erroresToolStripMenuItem.Name = "erroresToolStripMenuItem";
            this.erroresToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.erroresToolStripMenuItem.Text = "Errores";
            this.erroresToolStripMenuItem.Click += new System.EventHandler(this.erroresToolStripMenuItem_Click);
            // 
            // tablaDeSimbolosToolStripMenuItem
            // 
            this.tablaDeSimbolosToolStripMenuItem.Name = "tablaDeSimbolosToolStripMenuItem";
            this.tablaDeSimbolosToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.tablaDeSimbolosToolStripMenuItem.Text = "Tabla De Simbolos";
            this.tablaDeSimbolosToolStripMenuItem.Click += new System.EventHandler(this.tablaDeSimbolosToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeUsuarioToolStripMenuItem,
            this.manualTecnicoToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            this.manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            this.manualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            this.manualDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.manualDeUsuarioToolStripMenuItem_Click);
            // 
            // manualTecnicoToolStripMenuItem
            // 
            this.manualTecnicoToolStripMenuItem.Name = "manualTecnicoToolStripMenuItem";
            this.manualTecnicoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manualTecnicoToolStripMenuItem.Text = "Manual Tecnico";
            this.manualTecnicoToolStripMenuItem.Click += new System.EventHandler(this.manualTecnicoToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(954, 641);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(78, 35);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Personaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Vida:";
            // 
            // lblNombrePersonaje
            // 
            this.lblNombrePersonaje.AutoSize = true;
            this.lblNombrePersonaje.BackColor = System.Drawing.Color.Transparent;
            this.lblNombrePersonaje.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePersonaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNombrePersonaje.Location = new System.Drawing.Point(114, 17);
            this.lblNombrePersonaje.Name = "lblNombrePersonaje";
            this.lblNombrePersonaje.Size = new System.Drawing.Size(0, 22);
            this.lblNombrePersonaje.TabIndex = 13;
            // 
            // lblVidaPersonaje
            // 
            this.lblVidaPersonaje.AutoSize = true;
            this.lblVidaPersonaje.BackColor = System.Drawing.Color.Transparent;
            this.lblVidaPersonaje.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVidaPersonaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVidaPersonaje.Location = new System.Drawing.Point(114, 47);
            this.lblVidaPersonaje.Name = "lblVidaPersonaje";
            this.lblVidaPersonaje.Size = new System.Drawing.Size(0, 22);
            this.lblVidaPersonaje.TabIndex = 14;
            // 
            // panelSelectFondos
            // 
            this.panelSelectFondos.BackColor = System.Drawing.Color.Transparent;
            this.panelSelectFondos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelectFondos.Controls.Add(this.label6);
            this.panelSelectFondos.Controls.Add(this.btnSelectOTroFondo);
            this.panelSelectFondos.Controls.Add(this.pictureBoxFondoSelect);
            this.panelSelectFondos.Controls.Add(this.btnFondoSiguiente);
            this.panelSelectFondos.Controls.Add(this.btnFondoAnterior);
            this.panelSelectFondos.Location = new System.Drawing.Point(12, 391);
            this.panelSelectFondos.Name = "panelSelectFondos";
            this.panelSelectFondos.Size = new System.Drawing.Size(285, 285);
            this.panelSelectFondos.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 26);
            this.label6.TabIndex = 21;
            this.label6.Text = "Fondos";
            // 
            // btnSelectOTroFondo
            // 
            this.btnSelectOTroFondo.Location = new System.Drawing.Point(93, 255);
            this.btnSelectOTroFondo.Name = "btnSelectOTroFondo";
            this.btnSelectOTroFondo.Size = new System.Drawing.Size(75, 23);
            this.btnSelectOTroFondo.TabIndex = 20;
            this.btnSelectOTroFondo.Text = "Seleccionar";
            this.btnSelectOTroFondo.UseVisualStyleBackColor = true;
            this.btnSelectOTroFondo.Click += new System.EventHandler(this.btnSelectOTroFondo_Click_1);
            // 
            // pictureBoxFondoSelect
            // 
            this.pictureBoxFondoSelect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxFondoSelect.Location = new System.Drawing.Point(3, 41);
            this.pictureBoxFondoSelect.Name = "pictureBoxFondoSelect";
            this.pictureBoxFondoSelect.Size = new System.Drawing.Size(277, 166);
            this.pictureBoxFondoSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFondoSelect.TabIndex = 8;
            this.pictureBoxFondoSelect.TabStop = false;
            // 
            // btnFondoSiguiente
            // 
            this.btnFondoSiguiente.Location = new System.Drawing.Point(135, 226);
            this.btnFondoSiguiente.Name = "btnFondoSiguiente";
            this.btnFondoSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnFondoSiguiente.TabIndex = 6;
            this.btnFondoSiguiente.Text = "Siguiente";
            this.btnFondoSiguiente.UseVisualStyleBackColor = true;
            this.btnFondoSiguiente.Click += new System.EventHandler(this.btnFondoSiguiente_Click);
            // 
            // btnFondoAnterior
            // 
            this.btnFondoAnterior.Location = new System.Drawing.Point(59, 226);
            this.btnFondoAnterior.Name = "btnFondoAnterior";
            this.btnFondoAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnFondoAnterior.TabIndex = 5;
            this.btnFondoAnterior.Text = "Anterior";
            this.btnFondoAnterior.UseVisualStyleBackColor = true;
            this.btnFondoAnterior.Click += new System.EventHandler(this.btnFondoAnterior_Click);
            // 
            // panelSelectPersonaje
            // 
            this.panelSelectPersonaje.BackColor = System.Drawing.Color.Transparent;
            this.panelSelectPersonaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelectPersonaje.Controls.Add(this.richTextBox1);
            this.panelSelectPersonaje.Controls.Add(this.BtnSeleccionarOtroPersonaje);
            this.panelSelectPersonaje.Controls.Add(this.vidaPersonajeSelect);
            this.panelSelectPersonaje.Controls.Add(this.NombrePersonajeSelect);
            this.panelSelectPersonaje.Controls.Add(this.label5);
            this.panelSelectPersonaje.Controls.Add(this.label3);
            this.panelSelectPersonaje.Controls.Add(this.label4);
            this.panelSelectPersonaje.Controls.Add(this.pictureBox1);
            this.panelSelectPersonaje.Controls.Add(this.button4);
            this.panelSelectPersonaje.Controls.Add(this.button3);
            this.panelSelectPersonaje.Location = new System.Drawing.Point(12, 49);
            this.panelSelectPersonaje.Name = "panelSelectPersonaje";
            this.panelSelectPersonaje.Size = new System.Drawing.Size(285, 336);
            this.panelSelectPersonaje.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(119, 285);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(159, 44);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // BtnSeleccionarOtroPersonaje
            // 
            this.BtnSeleccionarOtroPersonaje.Location = new System.Drawing.Point(93, 204);
            this.BtnSeleccionarOtroPersonaje.Name = "BtnSeleccionarOtroPersonaje";
            this.BtnSeleccionarOtroPersonaje.Size = new System.Drawing.Size(75, 23);
            this.BtnSeleccionarOtroPersonaje.TabIndex = 20;
            this.BtnSeleccionarOtroPersonaje.Text = "Seleccionar";
            this.BtnSeleccionarOtroPersonaje.UseVisualStyleBackColor = true;
            this.BtnSeleccionarOtroPersonaje.Click += new System.EventHandler(this.BtnSeleccionarOtroPersonaje_Click);
            // 
            // vidaPersonajeSelect
            // 
            this.vidaPersonajeSelect.AutoSize = true;
            this.vidaPersonajeSelect.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vidaPersonajeSelect.ForeColor = System.Drawing.SystemColors.Control;
            this.vidaPersonajeSelect.Location = new System.Drawing.Point(113, 263);
            this.vidaPersonajeSelect.Name = "vidaPersonajeSelect";
            this.vidaPersonajeSelect.Size = new System.Drawing.Size(0, 22);
            this.vidaPersonajeSelect.TabIndex = 18;
            // 
            // NombrePersonajeSelect
            // 
            this.NombrePersonajeSelect.AutoSize = true;
            this.NombrePersonajeSelect.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombrePersonajeSelect.ForeColor = System.Drawing.SystemColors.Control;
            this.NombrePersonajeSelect.Location = new System.Drawing.Point(110, 241);
            this.NombrePersonajeSelect.Name = "NombrePersonajeSelect";
            this.NombrePersonajeSelect.Size = new System.Drawing.Size(0, 22);
            this.NombrePersonajeSelect.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(3, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "Vida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Personaje:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(59, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(135, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Siguiente";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(59, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Anterior";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblGanancia);
            this.panel1.Controls.Add(this.lblPerdida);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblVidaPersonaje);
            this.panel1.Controls.Add(this.lblNombrePersonaje);
            this.panel1.Location = new System.Drawing.Point(959, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanancia.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblGanancia.Location = new System.Drawing.Point(124, 69);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(0, 20);
            this.lblGanancia.TabIndex = 16;
            // 
            // lblPerdida
            // 
            this.lblPerdida.AutoSize = true;
            this.lblPerdida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerdida.ForeColor = System.Drawing.Color.Red;
            this.lblPerdida.Location = new System.Drawing.Point(56, 69);
            this.lblPerdida.Name = "lblPerdida";
            this.lblPerdida.Size = new System.Drawing.Size(0, 20);
            this.lblPerdida.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelEscenario);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Visor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelEscenario
            // 
            this.panelEscenario.AutoScroll = true;
            this.panelEscenario.Location = new System.Drawing.Point(0, 0);
            this.panelEscenario.Name = "panelEscenario";
            this.panelEscenario.Size = new System.Drawing.Size(629, 629);
            this.panelEscenario.TabIndex = 1;
            this.panelEscenario.Click += new System.EventHandler(this.panelEscenario_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(312, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 653);
            this.tabControl1.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto1_201325674.Properties.Resources.fondoImagenes2;
            this.ClientSize = new System.Drawing.Size(1171, 690);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSelectFondos);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelSelectPersonaje);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelSelectFondos.ResumeLayout(false);
            this.panelSelectFondos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFondoSelect)).EndInit();
            this.panelSelectPersonaje.ResumeLayout(false);
            this.panelSelectPersonaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panelSelectPersonaje;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarArchivoConfiguracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarArchivoDeCargaEscenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarJuegoToolStripMenuItem;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombrePersonaje;
        private System.Windows.Forms.Label lblVidaPersonaje;
        private System.Windows.Forms.Button BtnSeleccionarOtroPersonaje;
        private System.Windows.Forms.Label vidaPersonajeSelect;
        private System.Windows.Forms.Label NombrePersonajeSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelSelectFondos;
        private System.Windows.Forms.Button btnSelectOTroFondo;
        private System.Windows.Forms.PictureBox pictureBoxFondoSelect;
        private System.Windows.Forms.Button btnFondoSiguiente;
        private System.Windows.Forms.Button btnFondoAnterior;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label lblPerdida;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelEscenario;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTecnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem erroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaDeSimbolosToolStripMenuItem;
    }
}

