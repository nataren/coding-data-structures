def contains_duplicates(str):
    for i in xrange(0, len(str)):
        for j in str[i+1:]:
            if str[i] == j:
                return True
    return False

def check_permutation(s1, s2):
    if len(s1) != len(s2):
        return False

    s1_counts = [None] * 128
    for (c, x) in [(c, 1) for c in s1]:
        i = ord(c)
        if s1_counts[i] == None:
            s1_counts[i] = 1
        else:
            s1_counts[i] += 1

    s2_counts = [None] * 128
    for (c, x) in [(c, 1) for c in s2]:
        i = ord(c)
        if s2_counts[i] == None:
            s2_counts[i] = 1
        else:
            s2_counts[i] += 1
    return s1_counts == s2_counts

