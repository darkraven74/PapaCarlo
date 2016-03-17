using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class EmployeeTable
    {
        public Employee employee;
        public Position position;

        public EmployeeTable(Employee employee, Position position)
        {
            this.employee = employee;
            this.position = position;
        }
    }

    public class StoreCellTable
    {
        public StoreCell storeCell;
        public Storehouse storehouse;

        public StoreCellTable(StoreCell storeCell, Storehouse storehouse)
        {
            this.storeCell = storeCell;
            this.storehouse = storehouse;
        }
    }

    public class TechCardsTable
    {
        public TechnologicalCard technologicalCard;
        public List<ProductTechCard> productTechCard;

        public TechCardsTable(TechnologicalCard technologicalCard, List<ProductTechCard> productTechCard)
        {
            this.technologicalCard = technologicalCard;
            this.productTechCard = productTechCard;
        }
    }

    public class ContractMoveTable
    {
        public ContractMove contractMove;
        public StoreCell storeCellFrom;
        public StoreCell storeCellTo;
        public Storehouse storehouseFrom;
        public Storehouse storehouseTo;

        public ContractMoveTable(ContractMove contractMove, StoreCell storeCellFrom, StoreCell storeCellTo, Storehouse storehouseFrom, Storehouse storehouseTo)
        {
            this.contractMove = contractMove;
            this.storeCellFrom = storeCellFrom;
            this.storeCellTo = storeCellTo;
            this.storehouseFrom = storehouseFrom;
            this.storehouseTo = storehouseTo;
        }
    }

    public class ReportBalanceTable
    {
        public Product product;
        public StoreCell storeCell;
        public Storehouse storehouse;
        public ReportBalance reportBalance;

        public ReportBalanceTable(ReportBalance reportBalance, Product product, StoreCell storeCell, Storehouse storehouse)
        {
            this.product = product;
            this.storehouse = storehouse;
            this.storeCell = storeCell;
            this.reportBalance = reportBalance;
        }
    }

    public class ReportPredictTable
    {
        public Product product;
        public Storehouse storehouse;
        public ReportPredict reportPredict;
       // public ContractSupply contractSupply;

        public ReportPredictTable(ReportPredict reportPredict, Product product, Storehouse storehouse)
        {
            this.product = product;
            this.storehouse = storehouse;
            this.reportPredict = reportPredict;
            //this.contractSupply = contractSupply;
        }
    }

    public class ContractSupplyTable
    {
        public List<SupplyProduct> productList;
        public ContractSupply contractSupply ;
        public Contractor contractor;

        public ContractSupplyTable(ContractSupply contractSupply,  Contractor contractor)
        {
            this.contractSupply=contractSupply;
            this.contractor=contractor;
        }

        public ContractSupplyTable(ContractSupply contractSupply, List<SupplyProduct> productList)
        {
            this.contractSupply = contractSupply;
            this.productList = productList;
        }
    }

    public class ProductAmountTable
    {
        public Product product;
        public int amount;
        public int contractId;
        public int type = 0;

        public ProductAmountTable(int contractId, Product product, int amount)
        {
            this.product = product;
            this.amount = amount;
            this.contractId = contractId;
        }

        public ProductAmountTable(int contractId, Product product, int amount, int type) : this(contractId, product, amount)
        {
            this.type = type;
        }
    }

    public class ContractShipmentTable
    {
        public ContractShipment contractShipment;
        public StoreCell storeCellFrom;
        public Storehouse storehouseFrom;

        public ContractShipmentTable(ContractShipment contractShipment, StoreCell storeCellFrom, Storehouse storehouseFrom)
        {
            this.contractShipment = contractShipment;
            this.storeCellFrom = storeCellFrom;
            this.storehouseFrom = storehouseFrom;
        }
    }
}
