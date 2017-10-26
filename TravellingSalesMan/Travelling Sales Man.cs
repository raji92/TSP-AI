using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesMan
{
    public partial class Travelling_Sales_Man : Form
    {
        public Travelling_Sales_Man()
        {
            InitializeComponent();
            var costFunctionssource = new Dictionary<string, string>();
            costFunctionssource.Add("c1", "Cost function 1");
            costFunctionssource.Add("c2", "Cost function 2");
            costFunctionssource.Add("c3", "Cost function 3");

            var searchStrategiesSource = new Dictionary<string, string>();
            searchStrategiesSource.Add("s", "SIMP");
            searchStrategiesSource.Add("so", "SOPH");

            ddCostFunctions.DataSource = new BindingSource(costFunctionssource, null);
            ddCostFunctions.DisplayMember = "Value";
            ddCostFunctions.ValueMember = "key";

            ddStrategies.DataSource = new BindingSource(searchStrategiesSource, null);
            ddStrategies.DisplayMember = "Value";
            ddStrategies.ValueMember = "Key";
            lblCityError.Hide();
            lblMEBErr.Hide();
            lblResultMessage.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int MAX = int.MaxValue;
                int numberOfCities = int.Parse((txtCities.Text == null || txtCities.Text == string.Empty) ? "0" : txtCities.Text);
                int maximumEffortBound = Convert.ToInt32(txtMeb.Text == null || txtMeb.Text == string.Empty ? "0" : txtMeb.Text.ToString());
                if (numberOfCities == 0)
                {
                    lblCityError.Show();
                    return;
                }
                string selectedCostFunction = ddCostFunctions.SelectedValue.ToString();
                if (selectedCostFunction == string.Empty || selectedCostFunction == null)
                {
                    return;
                }
                string selectedStrategy = ddStrategies.SelectedValue.ToString();
                if (selectedStrategy == string.Empty || selectedStrategy == null)
                {
                    return;
                }
                lblCityError.Hide();
                int[,] costMatrix = GenerateCostMatrix(selectedCostFunction, numberOfCities);
                if (costMatrix != null && costMatrix.Length != 0)
                {
                    for (int i = 0; i < costMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < costMatrix.GetLength(1); j++)
                        {
                            if (i == j)
                            {
                                costMatrix[i, j] = MAX;
                            }
                        }
                    }
                }
                var finalText = new StringBuilder();
                if (selectedStrategy.ToLower() == "so")
                {

                    var solveTsp = new BranchAndBound();
                    var solution = solveTsp.SolveTSPProblem(costMatrix, maximumEffortBound);
                    bool writeToFile = FileHandler.WriteStreamToFile(solution, "so", maximumEffortBound);
                    lblResultMessage.Text = "Output is written to " + Environment.CurrentDirectory + "\\output.txt";
                    lblResultMessage.Show();
                }
                else
                {
                    var solveTsp = new NearestNeighbour();
                    var solution = solveTsp.SimpleSearch(costMatrix, maximumEffortBound);
                    bool writeToFile = FileHandler.WriteStreamToFile(solution, "s", maximumEffortBound);                    
                    lblResultMessage.Text = "Output is written to " + Environment.CurrentDirectory + "\\output.txt";
                    lblResultMessage.Show();
                }
            }
            catch (Exception ex)
            {
                FileHandler.WriteExceptionToFile(ex);
                lblResultMessage.Text = "";
                lblResultMessage.Text = "Exception occured check the Log file at " + Environment.CurrentDirectory + "\\ExceptionLog.txt" + "fore more details";
                lblResultMessage.Show();
            }
        }

        private int[,] GenerateCostMatrix(string selectedCostFunction, int numberOfCities)
        {
            int[,] initialCostMatrix = new int[numberOfCities, numberOfCities];
            for (int i = 0; i < numberOfCities; i++)
            {
                for (int j = 0; j < numberOfCities; j++)
                {
                    if (selectedCostFunction.ToLower() == "c1")
                    {
                        initialCostMatrix[i, j] = CostFunctions.CostFunction1(i, j);
                    }
                    else if (selectedCostFunction.ToLower() == "c2")
                    {
                        initialCostMatrix[i, j] = CostFunctions.CostFunction2(i, j);
                    }
                    else
                    {
                        initialCostMatrix[i, j] = CostFunctions.CostFunction3(i, j);
                    }

                }
            }
            return initialCostMatrix;
        }

        private void ddStrategies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Check = ddStrategies.SelectedValue.ToString();
            if (Check == "so")
            {
                txtMeb.Enabled = true;
            }
            else
            {
                txtMeb.Enabled = false;
            }
        }
    }
}
