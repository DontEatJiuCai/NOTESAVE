﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace NOTE.model
{
    class MyDrawBox : PictureBox
    {
        int width = 0;
        int height = 0;
        Bitmap btmp;
        Graphics graphics = null;
        Pen pen = null;
        int penSize = 3;
        Color penColor = Color.Black;
        PictureBox pictureBox = null;
        bool isDrawing = false;
        float x = 0;
        float y = 0;
        public MyDrawBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            width = pictureBox.Width;
            height = pictureBox.Height;
            btmp = new Bitmap(width, height);
            graphics = Graphics.FromImage(btmp);
            graphics.Clear(Color.White);
            pictureBox.Image = btmp;
            graphics.Dispose();
        }
        public void colorSelect(ColorDialog colorDialog)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog.Color;
            }
        }
        public void penSizeSelect(int size)
        {
            penSize = size;
        }
        public void mourseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                //设置画笔
                pen = new Pen(penColor, penSize);
                isDrawing = true;
            }
        }
        public void mourseMove(MouseEventArgs e)
        {
            if(isDrawing && (e.Button == MouseButtons.Left))
            {
                graphics = Graphics.FromImage(btmp);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.DrawLine(pen, new Point((int)x, (int)y), new Point(e.X, e.Y));
                pictureBox.Image = btmp; //在控件显示Bitmap
                x = e.X;
                y = e.Y;
                graphics.Dispose();
            }
        }
        public void mourseUp(MouseEventArgs e)
        {
            if(isDrawing || (e.Button == MouseButtons))
            {
                isDrawing = false;
            }
        }

    }
}
