# Prisoners dilemma

An implementation of the famous [prisoners dilemma](http://en.wikipedia.org/wiki/Prisoner's_dilemma) known from game theory. This project allows various strategies to be pitted against each other to see which strategy is the best strategy. For me personally, I wanted to verify that cooperative strategies, which initially do not seem like they can beat more selfish strategies, indeed performed better than selfish strategies.

# Implementation

The implementation of the prisoner's dilemma and the simulator can be found in the [**Domain**](src/Domain) project. There you'll find classes like [`CooperationChoicesPayoff`](src/Domain/CooperationChoicesPayoff.cs) and the base class for a strategy implementation: [`CooperationStrategy`](src/Domain/CooperationStrategy.cs). We have implemented three different cooperation strategies: 
 * [Naive](src/Domain/NaiveCooperationStrategy.cs): always cooperate.
 * [Evil](src/Domain/EvilCooperationStrategy.cs): always defect.
 * [Tit-for-tat](src/Domain/TitForTatCooperationStrategy.cs): start with cooperating, then just do the same as the opponent did last round.

To evaluate the fitness of the three strategies using the following code:

    var fitnessEvaluator = new CooperationStrategiesFitnessEvaluator();
    var strategyFitnesses = fitnessEvaluator.Evaluate();

You can also modify the cooperation choice payoffs and the number of rounds played:

    var fitnessEvaluator = new CooperationStrategiesFitnessEvaluator()
                                    {
                                        NumberOfRounds = 20,
                                        CooperationChoicesPayoff =
                                            {
                                                PayoffForCooperateAndCooperate = 4, 
                                                PayoffForCooperateAndDefect = -1, 
                                                PayoffForDefectAndCooperate = 8, 
                                                PayoffForDefectAndDefect = 2
                                            }
                                    };

    // Evaluate the fitness of the strategies using the custom payoffs and number of rounds
    var strategyFitnesses = fitnessEvaluator.Evaluate();

# Results
The original (default) payoffs are the following:
    
             | Cooperate | Defect |
-----------: | :-------: | :----: | 
**Cooperate** |    3      |    0   |
**Defect**    |    5      |    1   |

Now if we run a simulation using those payoffs and use 10 simulation rounds, we get the following payoffs for our three strategies:

Strategy    | Payoff
:---------: | :----:
Naive       | 90
Evil        | 84
Tit-for-tat | 99

We see that the tit-for-tat algorithm performs best, which is the same result as in the original simulation of the prisoner's dilemma.

## License
[Apache License 2.0](LICENSE.md)