import math


def rectangular_tower(height, width):
    """ This function handle client request of rectangle tower.
    in case the difference between the height and width is bigger than 5 it will return area calculation
    otherwise it will return scope calculation """
    diff = abs(height - width)
    return height * width if diff > 5 else 2 * (height + width)


def pyramid_tower(req, height, width):
    """ This function if the user request is equal to 1 function will return the scope calculation
    otherwise it will print the pyramid (if its able to)"""
    if req == 1:
        # To calculate a side of the pyramid,
        # the Pythagorean theorem is used (altitude in an isosceles triangle also intersects a base side, therefore -)
        # half a base side to the power of 2 and another height to the power of 2
        # will give me the side of the pyramid to the power of 2.
        return "pyramid scope is:" + "{:.3f}".format(2 * math.sqrt((width/2) ** 2 + height ** 2) + width)
    if width % 2 == 0 or width > height * 2:
        return "The pyramid cannot be printed"
    # Generate odd numbers between width and 1 (excluding width and 1)
    odd_numbers = list(range(3, width, 2)) # all odd numbers between width and 1
    num_row = (height - 2) // len(odd_numbers) # numbers of rows for each odd numbers are there in the pyramid
    rest = (height - 2) % len(odd_numbers) # number of rows that are the rest and going to be added in the top of the pyramid
    pyramid_rows = ""

    for num in odd_numbers:
        row = ' ' * ((width - num) // 2) + '*' * num + '\n' # adds spaces for pyramid look
        for _ in  range(num_row):
            pyramid_rows += row

    # These following lines handle the top and bottom of the pyramid
    pyramid_rows +='*' * width +'\n'
    pyramid_rows = (' ' * ((width - 3) // 2) + '***\n') * rest + ''.join(pyramid_rows) if rest > 0 else ''.join(pyramid_rows)
    return ' ' * (width//2) + '*\n' + pyramid_rows


while True:
    user_req = int(input("Pls choose 1 for a rectangular tower\n"
                     "Choose 2 for a triangular pyramid\n"
                     "3 to finish the program "))
    if user_req == 1 or user_req == 2:
        height = int(input("Pls enter the tower height"))
        width = int(input("Pls enter the tower width"))
        if user_req == 1:
            print("output is:", rectangular_tower(height, width))
        else: # user_req == 2
            request = int(input("Pls choose 1 for calculating the scope of the pyramid\n"
                                 "Choose 2 for printing the pyramid\n"))
            if request != 1 and request !=2:
                print("Err, option not exist")
            else:
                print(pyramid_tower(request, height, width))
    elif user_req == 3:
        break
    else:
        print("ERR, try again")
print("Exiting program... Tnx")