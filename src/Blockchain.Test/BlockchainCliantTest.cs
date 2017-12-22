using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockchain.Core.Common;
using System;
using Blockchain.Core.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Blockchain.Test
{
    [TestClass]
    public class BlockchainCliantTest
    {
        [TestMethod]
        public void BlockchainTest()
        {
            var bcc = BlockchainCliant.Instance;
            //BlockchainCliant.CreateNewBlock(nonce: 100, previousHash: null);
            var address1 = Guid.NewGuid().ToString().Replace("-", "");
            var address2 = Guid.NewGuid().ToString().Replace("-", "");

            var initOutput = new List<Output>();
            initOutput.Add(TransactionHelper.GetOutput(address1, 100));
            var io = TransactionHelper.CreateIO(initOutput, address1, address2, 30, 0);
            var tran = TransactionHelper.CreateTransaction(io.inputs, io.outputs);

            bcc.AddTransaction(tran);
            System.Diagnostics.Trace.WriteLine($"Address1 Balance {bcc.GetBalance(address1)}");
            System.Diagnostics.Trace.WriteLine($"Address2 Balance {bcc.GetBalance(address2)}");

            io = TransactionHelper.CreateIO(initOutput, address1, address2, 20, 0);
            tran = TransactionHelper.CreateTransaction(io.inputs, io.outputs);
            bcc.AddTransaction(tran);
            System.Diagnostics.Trace.WriteLine($"Address1 Balance {bcc.GetBalance(address1)}");
            System.Diagnostics.Trace.WriteLine($"Address2 Balance {bcc.GetBalance(address2)}");

            io = TransactionHelper.CreateIO(initOutput, address2, address1, 50, 0);
            tran = TransactionHelper.CreateTransaction(io.inputs, io.outputs);
            bcc.AddTransaction(tran);
            System.Diagnostics.Trace.WriteLine($"Address1 Balance {bcc.GetBalance(address1)}");
            System.Diagnostics.Trace.WriteLine($"Address2 Balance {bcc.GetBalance(address2)}");

        }
    }
}
