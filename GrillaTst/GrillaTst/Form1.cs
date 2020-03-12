using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrillaTst
{
    public partial class Form1 : Form
    {
        SortableBindingList<ClassBindingSource> _list;
        private DataTable _dataTable = null;
        private DataSet _dataSet = null;

        private SortedDictionary<int, string> _filtersaved = new SortedDictionary<int, string>();
        private SortedDictionary<int, string> _sortsaved = new SortedDictionary<int, string>();


        public Form1()
        {
            InitializeComponent();
            //set filter and sort saved
            _filtersaved.Add(0, "");
            _sortsaved.Add(0, "");

            comboBox_filtersaved.DataSource = new BindingSource(_filtersaved, null);
            comboBox_filtersaved.DisplayMember = "Key";
            comboBox_filtersaved.ValueMember = "Value";
            comboBox_filtersaved.SelectedIndex = -1;
            comboBox_sortsaved.DataSource = new BindingSource(_sortsaved, null);
            comboBox_sortsaved.DisplayMember = "Key";
            comboBox_sortsaved.ValueMember = "Value";
            comboBox_sortsaved.SelectedIndex = -1;

            //initialize dataset
            _dataTable = new DataTable();
            _dataSet = new DataSet();
            _list = new SortableBindingList<ClassBindingSource>();

            //initialize bindingsource
            bindingSource_main.DataSource = _list;

            //initialize datagridview
            advancedDataGridView_main.DataSource = bindingSource_main;

            //set bindingsource
            SetTestData();

        }

        private void button_load_Click(object sender, EventArgs e)
        {
            //add test data to bindsource
            AddTestData();
        }

        private void SetTestData()
        {
            _dataTable = _dataSet.Tables.Add("TableTest");
            _dataTable.Columns.Add("int", typeof(int));
            _dataTable.Columns.Add("decimal", typeof(decimal));
            _dataTable.Columns.Add("double", typeof(double));
            _dataTable.Columns.Add("date", typeof(DateTime));
            _dataTable.Columns.Add("datetime", typeof(DateTime));
            _dataTable.Columns.Add("string", typeof(string));
            _dataTable.Columns.Add("boolean", typeof(bool));
            _dataTable.Columns.Add("guid", typeof(Guid));
            _dataTable.Columns.Add("image", typeof(Bitmap));
            _dataTable.Columns.Add("timespan", typeof(TimeSpan));

            //bindingSource_main.DataMember = _dataTable.TableName;

            advancedDataGridViewSearchToolBar_main.SetColumns(advancedDataGridView_main.Columns);
        }

        private void AddTestData()
        {
            Random r = new Random();
            Image[] sampleimages = new Image[2];
            sampleimages[0] = Image.FromFile(Path.Combine(Application.StartupPath, @"imagenes\Green_button.png"));
            sampleimages[1] = Image.FromFile(Path.Combine(Application.StartupPath, @"imagenes\Green_button.png"));

            int maxMinutes = (int)((TimeSpan.FromHours(20) - TimeSpan.FromHours(10)).TotalMinutes);

            for (int i = 0; i <= 100; i++)
            {
                ClassBindingSource newRrw = new ClassBindingSource()
                {
                    IntData = i,
                    DecimalData = (decimal)i * 2 / 3,
                    DoubleData = i % 2 == 0 ? (double)i * 2 / 3 : (double)i / 2,
                    DateData = DateTime.Today.AddHours(i * 2).AddHours(i % 2 == 0 ? i * 10 + 1 : 0).AddMinutes(i % 2 == 0 ? i * 10 + 1 : 0).AddSeconds(i % 2 == 0 ? i * 10 + 1 : 0).AddMilliseconds(i % 2 == 0 ? i * 10 + 1 : 0).Date,
                    DatetimeData = DateTime.Today.AddHours(i * 2).AddHours(i % 2 == 0 ? i * 10 + 1 : 0).AddMinutes(i % 2 == 0 ? i * 10 + 1 : 0).AddSeconds(i % 2 == 0 ? i * 10 + 1 : 0).AddMilliseconds(i % 2 == 0 ? i * 10 + 1 : 0),
                    StringData = i * 2 % 3 == 0 ? null : i.ToString() + " str",
                    BooleanData = i % 2 == 0 ? true : false,
                    GuidData = Guid.NewGuid(),
                    ImageData = sampleimages[r.Next(0, 2)] as Bitmap,
                    Timespan = TimeSpan.FromHours(10).Add(TimeSpan.FromMinutes(r.Next(maxMinutes)))
                };
                _list.Add(newRrw);
                //_dataTable.Rows.Add(newrow);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //add test data to bindsource
            AddTestData();

            //setup datagridview
            advancedDataGridView_main.DisableFilterAndSort(advancedDataGridView_main.Columns["int"]);
            advancedDataGridView_main.SetFilterDateAndTimeEnabled(advancedDataGridView_main.Columns["datetime"], true);
            advancedDataGridView_main.SetSortEnabled(advancedDataGridView_main.Columns["guid"], false);
            advancedDataGridView_main.SortDESC(advancedDataGridView_main.Columns["double"]);
            advancedDataGridView_main.SetChecklistTextFilterRemoveNodesOnSearchMode(advancedDataGridView_main.Columns["decimal"], false);
        }

        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource_main.Filter = advancedDataGridView_main.FilterString;
            textBox_filter.Text = bindingSource_main.Filter;
        }

        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource_main.Sort = advancedDataGridView_main.SortString;
            textBox_sort.Text = bindingSource_main.Sort;
        }

        private void bindingSource_main_ListChanged(object sender, ListChangedEventArgs e)
        {
            textBox_total.Text = bindingSource_main.List.Count.ToString();
        }

        private void button_savefilters_Click(object sender, EventArgs e)
        {
            _filtersaved.Add((comboBox_filtersaved.Items.Count - 1) + 1, advancedDataGridView_main.FilterString);
            comboBox_filtersaved.DataSource = new BindingSource(_filtersaved, null);
            comboBox_filtersaved.SelectedIndex = comboBox_filtersaved.Items.Count - 1;
            _sortsaved.Add((comboBox_sortsaved.Items.Count - 1) + 1, advancedDataGridView_main.SortString);
            comboBox_sortsaved.DataSource = new BindingSource(_sortsaved, null);
            comboBox_sortsaved.SelectedIndex = comboBox_sortsaved.Items.Count - 1;
        }

        private void button_setsavedfilter_Click(object sender, EventArgs e)
        {
            if (comboBox_filtersaved.SelectedIndex != -1 && comboBox_sortsaved.SelectedIndex != -1)
                advancedDataGridView_main.LoadFilterAndSort(comboBox_filtersaved.SelectedValue.ToString(), comboBox_sortsaved.SelectedValue.ToString());
        }

        private void button_unloadfilters_Click(object sender, EventArgs e)
        {
            advancedDataGridView_main.CleanFilterAndSort();
            comboBox_filtersaved.SelectedIndex = -1;
            comboBox_sortsaved.SelectedIndex = -1;
        }

        private void advancedDataGridViewSearchToolBar_main_Search(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            bool restartsearch = true;
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = advancedDataGridView_main.CurrentCell.ColumnIndex + 1 >= advancedDataGridView_main.ColumnCount;
                bool endrow = advancedDataGridView_main.CurrentCell.RowIndex + 1 >= advancedDataGridView_main.RowCount;

                if (endcol && endrow)
                {
                    startColumn = advancedDataGridView_main.CurrentCell.ColumnIndex;
                    startRow = advancedDataGridView_main.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : advancedDataGridView_main.CurrentCell.ColumnIndex + 1;
                    startRow = advancedDataGridView_main.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }
            DataGridViewCell c = advancedDataGridView_main.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);
            if (c == null && restartsearch)
                c = advancedDataGridView_main.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    0,
                    0,
                    e.WholeWord,
                    e.CaseSensitive);
            if (c != null)
                advancedDataGridView_main.CurrentCell = c;
        }

    }

    public class ClassBindingSource
    {
        public int IntData { get; set; }
        public decimal DecimalData { get; set; }
        public double DoubleData { get; set; }
        public DateTime DateData { get; set; }
        public DateTime DatetimeData { get; set; }
        public string StringData { get; set; }
        public bool BooleanData { get; set; }
        public Guid GuidData { get; set; }
        public Bitmap ImageData { get; set; }
        public TimeSpan Timespan { get; set; }
    }


    /// <summary>
    /// Provides a generic collection that supports data binding and additionally supports sorting.
    /// See http://msdn.microsoft.com/en-us/library/ms993236.aspx
    /// If the elements are IComparable it uses that; otherwise compares the ToString()
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class SortableBindingList<T> : BindingList<T> where T : class
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        public SortableBindingList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        /// <param name="list">An <see cref="T:System.Collections.Generic.IList`1" /> of items to be contained in the <see cref="T:System.ComponentModel.BindingList`1" />.</param>
        public SortableBindingList(IList<T> list)
            : base(list)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the list is sorted.
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }

        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirection; }
        }

        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class; otherwise, returns null
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }

        /// <summary>
        /// Removes any sort applied with ApplySortCore if sorting is implemented
        /// </summary>
        protected override void RemoveSortCore()
        {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
            _isSorted = false; //thanks Luca
        }

        /// <summary>
        /// Sorts the items if overridden in a derived class
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;

            List<T> list = Items as List<T>;
            if (list == null) return;

            list.Sort(Compare);

            _isSorted = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }


        private int Compare(T lhs, T rhs)
        {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;
            return result;
        }

        private int OnComparison(T lhs, T rhs)
        {
            object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
            object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
            if (lhsValue == null)
            {
                return (rhsValue == null) ? 0 : -1; //nulls are equal
            }
            if (rhsValue == null)
            {
                return 1; //first has value, second doesn't
            }
            if (lhsValue is IComparable)
            {
                return ((IComparable)lhsValue).CompareTo(rhsValue);
            }
            if (lhsValue.Equals(rhsValue))
            {
                return 0; //both are the same
            }
            //not comparable, compare ToString
            return lhsValue.ToString().CompareTo(rhsValue.ToString());
        }


    }

    class Persona
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int DNI { get; set; }
        public int Edad { get; set; }
        public Decimal Saldo { get; set; }
    }
}
