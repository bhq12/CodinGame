package main
/**
=====================
TYPES
=====================
 **/
type GameState struct {
    // if 0 you need to score on the right of the map, if 1 you need to score on the left
    TeamId int 
    Score int
    OpponentScore int
    Magic int
    EntityCount int
    OpponentMagic string
    Wizards []Wizard
    Snaffles []Snaffle
    Bludgers []Bludger
}

type Coordinate struct {
    X int
    Y int
}

type EntityProperties struct {
    Id int
    X int
    Y int
    Radius int
    XVelocity int
    YVelocity int
    State int
}

type Wizard struct {
    IsOpponent bool
    Properties EntityProperties
}

type Snaffle struct {
    Properties EntityProperties
}

type Bludger struct {
    Properties EntityProperties
}

