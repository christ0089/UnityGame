def perfectSquare():
    number = float(input("Please Enter Number: "))
    x = number//2
    if number //2 != x**2:
        print("Number was perfect Square")
    else:
        perfectSquare()
perfectSquare()
