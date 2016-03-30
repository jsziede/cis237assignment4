//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        private IDroid[] aux;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //method used for quick testing to make an array without manually creating one through the interface
        public void CreateDummyData()
        {
            droidCollection[0] = new ProtocolDroid("Carbonite", "Protocol", "Bronze", 5);
            droidCollection[1] = new JanitorDroid("Carbonite", "Janitor", "Bronze", true, true, true, true, true);
            droidCollection[2] = new AstromechDroid("Quadranium", "Astromech", "Gold", false, true, false, true, 3);
            droidCollection[3] = new ProtocolDroid("Vanadium", "Protocol", "Bronze", 2);
            droidCollection[4] = new UtilityDroid("Carbonite", "Utility", "Silver", true, false, true);
            droidCollection[5] = new UtilityDroid("Quadranium", "Utility", "Gold", false, false, false);
            droidCollection[6] = new AstromechDroid("Quadranium", "Astromech", "Silver", true, true, true, true, 6);
            droidCollection[7] = new UtilityDroid("Carbonite", "Utility", "Bronze", false, false, true);
            droidCollection[8] = new JanitorDroid("Vanadium", "Janitor", "Bronze", true, false, false, false, true);
            droidCollection[9] = new ProtocolDroid("Quadranium", "Protocol", "Gold", 4);
            droidCollection[10] = new JanitorDroid("Vanadium", "Janitor", "Silver", false, false, false, false, false);
            droidCollection[11] = new JanitorDroid("Quadranium", "Janitor", "Gold", true, false, true, false, true);
            droidCollection[12] = new UtilityDroid("Vanadium", "Utility", "Silver", true, true, true);
            droidCollection[13] = new AstromechDroid("Carbonite", "Astromech", "Bronze", false, false, false, false, 13);
            droidCollection[14] = new AstromechDroid("Carbonite", "Astromech", "Gold", true, false, true, false, 24);
            droidCollection[15] = new ProtocolDroid("Carbonite", "Protocol", "Silver", 7);

            //the amount of non-null elements is accumulated by 16
            lengthOfCollection = lengthOfCollection + 16;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }

        //method to sort droids by model using bucket sort
        public void SortByModel()
        {
            //generic stack instanciations for each type of droid
            GenericStack<IDroid> protocolDroidStack = new GenericStack<IDroid>();
            GenericStack<IDroid> utilityDroidStack = new GenericStack<IDroid>();
            GenericStack<IDroid> janitorDroidStack = new GenericStack<IDroid>();
            GenericStack<IDroid> astromechDroidStack = new GenericStack<IDroid>();

            //generic queue instanciation
            GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

            //counters used to run through the array and each generic stack
            int counter = 0;
            int protocolCounter = 0;
            int utilityCounter = 0;
            int janitorCounter = 0;
            int astromechCounter = 0;

            //while loop to run through the droid array
            while (counter < lengthOfCollection)
            {
                //checks if the current element is of type ProtocolDroid
                if (droidCollection[counter].GetType() == typeof(ProtocolDroid))
                {
                    //pushes the current element into the Protocol Droid stack
                    protocolDroidStack.Push(droidCollection[counter]);
                    //increments the counter used to determine how many droids are in the protocol stack
                    protocolCounter++;
                }
                //checks if the current element is of type UtilityDroid
                else if (droidCollection[counter].GetType() == typeof(UtilityDroid))
                {
                    //pushes the current element into the Utility Droid stack
                    utilityDroidStack.Push(droidCollection[counter]);
                    //increments the counter used to determine how many droids are in the utility stack
                    utilityCounter++;
                }
                //checks if the current element is of type JanitorDroid
                else if (droidCollection[counter].GetType() == typeof(JanitorDroid))
                {
                    //pushes the current element into the Janitor Droid stack
                    janitorDroidStack.Push(droidCollection[counter]);
                    //increments the counter used to determine how many droids are in the janitor stack
                    janitorCounter++;
                }
                //checks if the current element is of type AstromechDroid
                else if (droidCollection[counter].GetType() == typeof(AstromechDroid))
                {
                    //pushes the current element into the Astromech Droid stack
                    astromechDroidStack.Push(droidCollection[counter]);
                    //increments the counter used to determine how many droids are in the astromech stack
                    astromechCounter++;
                }

                //the while counter is incremented by one for each loop
                counter++;
            }

            //counter to determine how many times a type of droid stack has been popped
            int popCounter = 0;

            //while loop ran for each astromech droid in its stack
            while (popCounter < astromechCounter)
            {
                //the last droid in the astromech stack is popped and then enqueued into the general droid queue
                droidQueue.Enqueue(astromechDroidStack.Pop());
                //pop counter is incremented by one
                popCounter++;
            }

            //the same pop counter is reused
            popCounter = 0;

            //while loop ran for each janitor droid in its stack
            while (popCounter < janitorCounter)
            {
                //the last droid in the janitor stack is popped and then enqueued into the general droid queue
                droidQueue.Enqueue(janitorDroidStack.Pop());
                //pop counter is incremented by one
                popCounter++;
            }

            //the same pop counter is reused
            popCounter = 0;

            //while loop ran for each utility droid in its stack
            while (popCounter < utilityCounter)
            {
                //the last droid in the utility stack is popped and then enqueued into the general droid queue
                droidQueue.Enqueue(utilityDroidStack.Pop());
                //pop counter is incremented by one
                popCounter++;
            }

            //the same pop counter is reused
            popCounter = 0;

            //while loop ran for each protocol droid in its stack
            while (popCounter < protocolCounter)
            {
                //the last droid in the protocol stack is popped and then enqueued into the general droid queue
                droidQueue.Enqueue(protocolDroidStack.Pop());
                //pop counter is incremented by one
                popCounter++;
            }

            //the counter is reused and reset to zero for another while loop
            counter = 0;

            //while loop to run through the entire droid array
            while (counter <= lengthOfCollection)
            {
                //each element in the array that was not null is filled from the dequeue of the droid queue
                  //the first droid in the queue is added to the current position in the array
                droidCollection[counter] = droidQueue.Dequeue();
                //counter is incremented and used to move to the next element in the array
                counter++;
            }
        }

        //the method that prepares the sort and calls the sort method
        public void MergeSortMethod()
        {
            //instanciate merge class
            MergeSort merge = new MergeSort();

            //basic counter to count the used elements in the droid array
            int counter = 0;

            //checks to avoid any null elements
            while (droidCollection[counter] != null)
            {
                //calculates the total cost for each droid so the merge actually has data to compare
                droidCollection[counter].CalculateTotalCost();

                //increment counter
                counter++;
            }

            //call to the actual sort method
            merge.Sort(droidCollection);
        }
    }
}
