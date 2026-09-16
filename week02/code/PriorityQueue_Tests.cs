using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add two items with the same priority to the queue.
    // Expected Result: The first item added should be removed first.
    // Defect(s) Found: The queue returned the last item added when items had the same priority.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 1);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority should be removed first.

    // Defect(s) Found: The loop did not check the last item in the queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 8);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Add two items with different priorities and dequeue twice.
    // Expected Result: The highest-priority item is removed first, followed by the remaining item.
    // Defect(s) Found: The Dequeue method returned the item but did not remove it from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("B", first);
        Assert.AreEqual("A", second);
    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority.
    // Expected Result: The item closest to the front of the queue should be removed first.
    // Defect(s) Found: When two items had the same highest priority, the queue removed the item added later instead of the item closest to the front.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Try to dequeue an empty priority queue.
    // Expected Result: An InvalidOperationException with the message "The queue is empty." is thrown.
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}