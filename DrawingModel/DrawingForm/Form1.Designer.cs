﻿namespace DrawingForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._canvas = new System.Windows.Forms.Panel();
            this._tableLayoutPanelShape = new System.Windows.Forms.TableLayoutPanel();
            this._buttonClear = new System.Windows.Forms.Button();
            this._buttonRectangle = new System.Windows.Forms.Button();
            this._buttonLine = new System.Windows.Forms.Button();
            this._buttonEllipse = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._buttonRedo = new System.Windows.Forms.Button();
            this._buttonUndo = new System.Windows.Forms.Button();
            this._buttonUpload = new System.Windows.Forms.Button();
            this._tableLayoutPanel.SuspendLayout();
            this._tableLayoutPanelShape.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // _tableLayoutPanel
            //
            this._tableLayoutPanel.ColumnCount = 3;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.26994F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.29652F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.53579F));
            this._tableLayoutPanel.Controls.Add(this._canvas, 1, 1);
            this._tableLayoutPanel.Controls.Add(this._tableLayoutPanelShape, 0, 1);
            this._tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.467456F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.53255F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(978, 676);
            this._tableLayoutPanel.TabIndex = 0;
            //
            // _canvas
            //
            this._canvas.BackColor = System.Drawing.Color.LightYellow;
            this._tableLayoutPanel.SetColumnSpan(this._canvas, 2);
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(122, 67);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(853, 606);
            this._canvas.TabIndex = 3;
            this._canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.HandleCanvasPaint);
            this._canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleCanvasPressed);
            this._canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandleCanvasMoved);
            this._canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HandleCanvasReleased);
            //
            // _tableLayoutPanelShape
            //
            this._tableLayoutPanelShape.ColumnCount = 1;
            this._tableLayoutPanelShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanelShape.Controls.Add(this._buttonClear, 0, 0);
            this._tableLayoutPanelShape.Controls.Add(this._buttonRectangle, 0, 1);
            this._tableLayoutPanelShape.Controls.Add(this._buttonLine, 0, 2);
            this._tableLayoutPanelShape.Controls.Add(this._buttonEllipse, 0, 3);
            this._tableLayoutPanelShape.Location = new System.Drawing.Point(3, 67);
            this._tableLayoutPanelShape.Name = "_tableLayoutPanelShape";
            this._tableLayoutPanelShape.RowCount = 4;
            this._tableLayoutPanelShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanelShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanelShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanelShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanelShape.Size = new System.Drawing.Size(113, 279);
            this._tableLayoutPanelShape.TabIndex = 4;
            //
            // _buttonClear
            //
            this._buttonClear.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonClear.Location = new System.Drawing.Point(3, 3);
            this._buttonClear.Name = "_buttonClear";
            this._buttonClear.Size = new System.Drawing.Size(107, 63);
            this._buttonClear.TabIndex = 2;
            this._buttonClear.Text = "Clear";
            this._buttonClear.UseVisualStyleBackColor = true;
            this._buttonClear.Click += new System.EventHandler(this.HandleClearButtonClick);
            //
            // _buttonRectangle
            //
            this._buttonRectangle.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonRectangle.Location = new System.Drawing.Point(3, 72);
            this._buttonRectangle.Name = "_buttonRectangle";
            this._buttonRectangle.Size = new System.Drawing.Size(107, 63);
            this._buttonRectangle.TabIndex = 0;
            this._buttonRectangle.Text = "Rectangle";
            this._buttonRectangle.UseVisualStyleBackColor = true;
            this._buttonRectangle.Click += new System.EventHandler(this.ClickButtonRectangle);
            //
            // _buttonLine
            //
            this._buttonLine.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonLine.Location = new System.Drawing.Point(3, 141);
            this._buttonLine.Name = "_buttonLine";
            this._buttonLine.Size = new System.Drawing.Size(107, 63);
            this._buttonLine.TabIndex = 1;
            this._buttonLine.Text = "Line";
            this._buttonLine.UseVisualStyleBackColor = true;
            this._buttonLine.Click += new System.EventHandler(this.ClickButtonLine);
            //
            // _buttonEllipse
            //
            this._buttonEllipse.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonEllipse.Location = new System.Drawing.Point(3, 210);
            this._buttonEllipse.Name = "_buttonEllipse";
            this._buttonEllipse.Size = new System.Drawing.Size(107, 66);
            this._buttonEllipse.TabIndex = 0;
            this._buttonEllipse.Text = "Ellipse";
            this._buttonEllipse.UseVisualStyleBackColor = true;
            this._buttonEllipse.Click += new System.EventHandler(this.ClickButtonEllipse);
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this._buttonRedo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._buttonUndo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._buttonUpload, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(122, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 58);
            this.tableLayoutPanel1.TabIndex = 5;
            //
            // _buttonRedo
            //
            this._buttonRedo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonRedo.Enabled = false;
            this._buttonRedo.Location = new System.Drawing.Point(3, 3);
            this._buttonRedo.Name = "_buttonRedo";
            this._buttonRedo.Size = new System.Drawing.Size(139, 52);
            this._buttonRedo.TabIndex = 0;
            this._buttonRedo.Text = "Redo";
            this._buttonRedo.UseVisualStyleBackColor = true;
            this._buttonRedo.Click += new System.EventHandler(this.ClickButtonRedo);
            //
            // _buttonUndo
            //
            this._buttonUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonUndo.Enabled = false;
            this._buttonUndo.Location = new System.Drawing.Point(148, 3);
            this._buttonUndo.Name = "_buttonUndo";
            this._buttonUndo.Size = new System.Drawing.Size(139, 52);
            this._buttonUndo.TabIndex = 1;
            this._buttonUndo.Text = "Undo";
            this._buttonUndo.UseVisualStyleBackColor = true;
            this._buttonUndo.Click += new System.EventHandler(this.ClickButtonUndo);
            //
            // _buttonUpload
            //
            this._buttonUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonUpload.Location = new System.Drawing.Point(293, 3);
            this._buttonUpload.Name = "_buttonUpload";
            this._buttonUpload.Size = new System.Drawing.Size(140, 52);
            this._buttonUpload.TabIndex = 2;
            this._buttonUpload.Text = "Upload";
            this._buttonUpload.UseVisualStyleBackColor = true;
            this._buttonUpload.Click += new System.EventHandler(this.ClickButtonUpload);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 676);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanelShape.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Button _buttonRectangle;
        private System.Windows.Forms.Button _buttonLine;
        private System.Windows.Forms.Button _buttonClear;
        private System.Windows.Forms.Panel _canvas = new DoubleBufferedPanel();
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanelShape;
        private System.Windows.Forms.Button _buttonEllipse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _buttonRedo;
        private System.Windows.Forms.Button _buttonUndo;
        private System.Windows.Forms.Button _buttonUpload;
    }
}

