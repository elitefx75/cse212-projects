using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Add three items with different priorities.
    // Expected Result: 
    //  The item with the highest priority should be returned.
    // Defect(s) Found: 
    // Dequeue does not check the last item in the queue when searching for the highest priority.

    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue("Bob", 1);
            priorityQueue.Enqueue("Tim", 2);
            priorityQueue.Enqueue("Sue", 10);

            var result = priorityQueue.Dequeue();

             Assert.AreEqual("Sue", result);
        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Remove the highest priority item and verify it is no longer in the queue.
// Expected Result: The dequeued item should be removed from the queue.
// Defect(s) Found:
// Dequeue returns the highest priority item but does not remove it from the queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
         priorityQueue.Enqueue("Bob", 1);
    priorityQueue.Enqueue("Tim", 5);

    var first = priorityQueue.Dequeue();
    var second = priorityQueue.Dequeue();

    Assert.AreEqual("Tim", first);
    Assert.AreEqual("Bob", second);
        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}