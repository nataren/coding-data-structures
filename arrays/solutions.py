def contains_duplicates(str):
    for i in range(0, len(str)):
        for j in str[i+1:]:
            if str[i] == j:
                return True
    return False
