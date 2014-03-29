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
    public enum ViewMode
    {
        ForGroup,
        ForTeacher,
        ForClassroom
    }

    partial class VisualLesson : UserControl
    {
        private Lesson lesson;
        ViewMode mode;
        public VisualLesson()
        {
            InitializeComponent();
            mode = ViewMode.ForGroup;
        }
        public ViewMode Mode
        {
            get { return mode; }
            set
            {
                if (value == mode)
                    return;
                mode = value;
                DisplayLesson();
            }
        }
        public Lesson Lesson
        {
            get { return lesson; }
            set
            {
                if (value == lesson)
                    return;
                lesson = value;
                SetPosition();
                DisplayLesson();
            }
        }
        private void DisplayLesson()
        {
            this.topLabel.Text = lesson.Subject.Title;
            switch (mode)
            {
                case ViewMode.ForGroup:
                    this.middleLabel.Text = lesson.TitleClassroomsInColumn;
                    this.bottomLabel.Text = lesson.TitleTeachersInColumn;
                    break;
                case ViewMode.ForTeacher:
                    this.middleLabel.Text = lesson.TitleClassroomsInColumn;
                    this.bottomLabel.Text = lesson.TitleGroupsInColumn;
                    break;
                case ViewMode.ForClassroom:
                    this.middleLabel.Text = lesson.TitleGroupsInColumn;
                    this.bottomLabel.Text = lesson.TitleTeachersInColumn;
                    break;
            }
            if ((mode != ViewMode.ForTeacher)&&(lesson.Type == 0))
            {
                if (lesson.Teachers.Count() > 1)
                {
                    bottomLabel.Top = this.Height - 16 * lesson.Teachers.Count();
                }
            }
        }

        private void SetPosition()
        {
            this.Top = lesson.Number * this.Height * 2;
            this.Left = lesson.DayOfWeek * this.Width;
            switch (Lesson.Type)
            {
                case 0: this.Height *= 2; return;
                case 1: return;
                case 2: this.Top += this.Height; return;
            }
        }
    }
}
