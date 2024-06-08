package main
import ( 
    "fmt"
    "math"
    "os"
    "strconv"
)

/**
 * Grab Snaffles and try to throw them through the opponent's goal!
 * Move towards a Snaffle and use your team id to determine where you need to throw it.
 **/


/**
=====================
LOGIC
=====================
 **/

func distance(x1 int, x2 int, y1 int, y2 int) float64 {
    xDistance := float64(x1) - float64(x2)
    yDistance := float64(y1) - float64(y1)
    return math.Sqrt(math.Pow(xDistance, 2) + math.Pow(yDistance, 2))
}

func findClosestSnaffle(wizard Wizard, snaffles []Snaffle, ignoreIndex int) int {
    shortestDistance := float64(-1)
    var closestSnaffleIndex int
    for index, snaffle := range snaffles {
        if index == ignoreIndex {
            continue
        }
        distanceToSnaffle := distance(
            wizard.Properties.X,
            snaffle.Properties.X,
            wizard.Properties.Y,
            snaffle.Properties.Y,
        )
        if shortestDistance == -1 || distanceToSnaffle < shortestDistance {
            shortestDistance = distanceToSnaffle
            closestSnaffleIndex = index
        }
    }
    return closestSnaffleIndex
}

func main() {
    // myTeamId: if 0 you need to score on the right of the map, if 1 you need to score on the left
    var myTeamId int
    fmt.Scan(&myTeamId)
    
    for {
        var myScore, myMagic int
        fmt.Scan(&myScore, &myMagic)
        
        var opponentScore, opponentMagic int
        fmt.Scan(&opponentScore, &opponentMagic)
        
        // entities: number of entities still in game
        var entities int
        fmt.Scan(&entities)

        wizards :=  []Wizard{}
        opponentWizards := []Wizard{}
        snaffles := []Snaffle{}
        bludgers := []Bludger{}
        
        for i := 0; i < entities; i++ {
            // entityId: entity identifier
            // entityType: "WIZARD", "OPPONENT_WIZARD" or "SNAFFLE" (or "BLUDGER" after first league)
            // x: position
            // y: position
            // vx: velocity
            // vy: velocity
            // state: 1 if the wizard is holding a Snaffle, 0 otherwise
            var entityId int
            var entityType string
            var x, y, vx, vy, state int
            fmt.Scan(&entityId, &entityType, &x, &y, &vx, &vy, &state)

            entityProperties := EntityProperties {
                Id: entityId,
                X: x,
                Y: y,
                Radius: 1,//Gets introduced later
                XVelocity: vx,
                YVelocity: vy,
                State: state,
            }

            if entityType == "WIZARD" {
                newWizard := Wizard{
                    IsOpponent: false,
                    Properties: entityProperties,
                }

                wizards = append(wizards, newWizard)
            }
            if entityType == "OPPONENT_WIZARD" {
                newWizard := Wizard{
                    IsOpponent: true,
                    Properties: entityProperties,
                }
                opponentWizards = append(opponentWizards, newWizard)

            }
            if entityType == "SNAFFLE" {
                newSnaffle := Snaffle{
                    Properties: entityProperties,
                }
                snaffles = append(snaffles, newSnaffle)

            }
            if entityType == "BLUDGER" {
                newBludger := Bludger{
                    Properties: entityProperties,
                }
                bludgers = append(bludgers, newBludger)
            }
        }

        previousClosestSnaffleIndex := -1
        for i := 0; i < 2; i++ {
            wizard  := wizards[i]

            closestSnaffleIndex := findClosestSnaffle(wizard, snaffles, previousClosestSnaffleIndex)
            closestSnaffle := snaffles[closestSnaffleIndex]


            fmt.Fprintln(os.Stderr, "Len of wizards: + ", len(wizards))
            // Edit this line to indicate the action for each wizard (0 ≤ thrust ≤ 150, 0 ≤ power ≤ 500)
            // i.e.: "MOVE x y thrust" or "THROW x y power"
            if wizard.Properties.State == 0 {
                //Not holding snaffle
                fmt.Println("MOVE " + strconv.Itoa(closestSnaffle.Properties.X) + " " + strconv.Itoa(closestSnaffle.Properties.Y) +  " 150")
            } else {
                //Holding snaffle

                if myTeamId == 1 {
                    fmt.Println("THROW 0 3750 500")
                } else {
                    fmt.Println("THROW 16000 3750 500")
                }

            }
            previousClosestSnaffleIndex = closestSnaffleIndex

        }
    }
}
