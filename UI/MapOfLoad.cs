using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Susie
{
    partial class MapOfLoad : UserControl
    {
        public MapOfLoad()
        {
            InitializeComponent();
        }
        public void Assign(List<Lesson> L)
        {
            panel1.Controls.Clear();
            if (L == null) return;
            AddRange(L);
        }
        public void AddRange(List<Lesson> L)
        {
            foreach(Lesson l in L)
                AddLesson(l);
        }
        public void AddLesson(Lesson L)
        {
            LessonButton btn = new LessonButton();
            panel1.Controls.Add(btn);
            btn.Lesson = L;
        }
    }
    class LessonButton : Button
    {
        const int constWidth = 30;
        const int constHeight = 30;
        const int topOffset = 0;
        const int leftOffset = 0;

        private Lesson lesson;
        public LessonButton()
        {
            Width = constWidth;
            Height = constHeight;
            Click += new EventHandler(LessonButtonClick);
        }

        private void LessonButtonClick(object sender, EventArgs e)
        {
            lesson.ShowInformation();
        }
        public Lesson Lesson
        {
            get { return lesson; }
            set
            {
                if (lesson == value) return;
                lesson = value;
                SetPosition();
            }
        }
        private void SetPosition()
        {
            Left = lesson.Day * constWidth + leftOffset;
            Top = lesson.Number * constHeight + topOffset;
            if (lesson.Type != 0)
            {
                Height = constHeight / 2;
                if (lesson.Type == 2)
                    Top += constHeight / 2;
            }

        }

    }
}
