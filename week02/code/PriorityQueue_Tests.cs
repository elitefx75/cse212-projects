
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities.
    // Expected Result: The item with the highest priority is removed first.
    // Defect(s) Found: To be determined after running the test.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Book", 1);
        priorityQueue.Enqueue("Laptop", 5);
        priorityQueue.Enqueue("Phone", 3);

        Assert.AreEqual("Laptop", priorityQueue.Dequeue());
        Assert.AreEqual("Phone", priorityQueue.Dequeue());
        Assert.AreEqual("Book", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with equal priorities and attempt to dequeue from an empty queue.
    // Expected Result: Equal priorities follow FIFO order, and an empty queue throws
    // InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: To be determined after running the test.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
