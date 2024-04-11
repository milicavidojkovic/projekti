from Controllers.GameState import GameState
from ImportedScripts.TextColorizer.ColorizeText import colored
#from GameInitializer import is_empty
from Interface.Stack import Stack
def printWelcomeText():
    print(colored("\n-----------------------------------\n", 'red', attrs=['bold']))
    print(colored(" Welcome to the BYTE GAME!", 'red', attrs=['bold']))
    print(colored("\n-----------------------------------\n", 'red', attrs=['bold']))

def getWhoPlaysFirst():
    whoPlaysFirst = ""
    while(whoPlaysFirst != "me" and whoPlaysFirst != "cpu"):
        whoPlaysFirst = input(colored("Who do you want to play first? Type me/cpu: ", 'cyan')).lower()
    return whoPlaysFirst

def getTableDimensions(maxDim:int):
    print(colored("\nLet's create the table!", 'yellow'))
    print(f' Tip: Recommended dimensions are 8x8\n Rule: Max dimensions are {maxDim}x{maxDim}, Minimum dimensions are 5x5!\n')
    
    dim = -1
    #parno, maks 16, valjda ne moze manje od 4 zbog onog da treba prva dva steka na pocetku da su prazna, 
    #a i ovaj uslov da broj figurica mora da je deljiv sa 8
    while(dim < 4 or dim > maxDim or dim % 2 != 0 or ((int(dim/2) * (dim-2)) % 8 != 0)):
        try:
            dim = int(input(colored("Enter the number of rows: ", 'cyan')))
        except:
            print(colored("Invalid input", 'red', attrs=['bold']))

    return (dim)

def makeBegginingStacks(n):
    flag = 0
    stekovi = []
    dim = int(n /2)
        
    for i in range(0, n * dim):
        stek = Stack()
        stekovi.append(stek)
        if i < dim or i >= (n-1)* dim :
             continue
        
        elif flag == 0:
            stek.makeBeginingStack("O")
        else :
            stek.makeBeginingStack("X")
        if i % dim == (dim - 1):
            flag = not flag
    
    return stekovi

def makeBeginningMatrix(n, stacks):
    matrix = [[None] * n for _ in range(n)]

    stack_counter = 0
    for i in range(n):
        if i == 0 or i == n - 1:
            continue  # Skip first and last row
        elif i % 2 == 0:
            for j in range(0, n, 2):
                matrix[i][j] = stacks[stack_counter] if stack_counter < len(stacks) else None
                stack_counter += 1
        else:
            for j in range(1, n, 2):
                matrix[i][j] = stacks[stack_counter] if stack_counter < len(stacks) else None
                stack_counter += 1

    return matrix

def initializeGameState(dim:int, whoPlaysFirst:str):
    state:GameState = GameState()
    state.playerSign = "X" if whoPlaysFirst == "me" else "O"
    state.cpuSign = "X" if whoPlaysFirst == "cpu" else "O"
    state.currentTurn = "X"
    state.dimension = dim
    state.stekovi = makeBegginingStacks(dim)
    state.matrix = makeBeginningMatrix(dim, state.stekovi)
    return state

def intializeGame(maxDimension:int):
    printWelcomeText()
    whoPlaysFirst = getWhoPlaysFirst()
    dimensions = getTableDimensions(maxDimension) 
    return initializeGameState(dimensions, whoPlaysFirst)


def gameIsOver(state):
    #state:GameState = GameState()
    winner:str
    j:int
    j=len(state.stekovi)
    gameOver:bool=True
    for stek in state.stekovi:
        if len(stek.array)!=0:
           gameOver=False
    if((state.playerScore*8>=len(state.stekovi)/2) or (state.cpuScore*8>=len(state.stekovi)/2)):
        gameOver=True
    if(gameOver==True):
        if(state.playerScore>state.cpuScore):
            winner="PLAYER"
        else :
            winner="CPU"
        print(colored("\n-----------------------------------\n", 'red', attrs=['bold']))
        print(colored(" GAME IS OVER! ", 'red', attrs=['bold']))
        print(colored("\n-----------------------------------\n", 'red', attrs=['bold']))
        print(colored(f"{winner} IS A WINNER! ", 'red', attrs=['bold']))
        print(colored("\n-----------------------------------\n", 'red', attrs=['bold']))
        return True
    else:
        return False
    




