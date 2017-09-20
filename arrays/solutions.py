def oneway(s1, s2):
    s1_len = len(s1)
    s2_len = len(s2)
    if s1_len == s2_len:
        diff_count = 0
        for i in range(0, s1_len):
            if s1[i] != s2[i]:
                diff_count += 1
            if diff_count > 1:
                return False
        return True
    elif s1_len < s2_len:
        diff_count = 0
        i = 0
        j = 0
        while i < s1_len:
            if diff_count > 1:
                return False
            if s1[i] != s2[j]:
                j += 1
                diff_count += 1
                continue
            i+=1
            j+=1
        return diff_count <= 1
    elif s2_len < s1_len:
        diff_count = 0
        i = 0
        j = 0
        while j < s2_len:
            if diff_count > 1:
                return False
            if s2[j] != s1[i]:
                i += 1
                diff_count += 1
                continue
            i+=1
            j+=1
        return diff_count <= 1

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
    for c in s1:
        i = ord(c)
        if s1_counts[i] == None:
            s1_counts[i] = 1
        else:
            s1_counts[i] += 1

    s2_counts = [None] * 128
    for c in s2:
        i = ord(c)
        if s2_counts[i] == None:
            s2_counts[i] = 1
        else:
            s2_counts[i] += 1
    return s1_counts == s2_counts

def urlify(s):
    return ''.join(c for c in [
        x if x != ' ' else '%20' for x in s
    ])

def compress(s):
    class Item(object):
        def __init__(self, character, counter):
            self.character  = character
            self.counter = counter

    if s is None or s == '':
        return s

    tracker = []
    prev = None
    current = None
    current_counter = 0

    for i in range(0, len(s)):
        current = s[i]

        if prev == current:
            current_counter += 1
            t = tracker[len(tracker) - 1]
            t.counter = current_counter
        else:
            prev = current
            current_counter = 1
            tracker.append(Item(
                current,
                current_counter
            ))

    ns = ''

    for t in tracker:
        ns += t.character + str(t.counter)

    return ns if len(ns) < len(s) else s

