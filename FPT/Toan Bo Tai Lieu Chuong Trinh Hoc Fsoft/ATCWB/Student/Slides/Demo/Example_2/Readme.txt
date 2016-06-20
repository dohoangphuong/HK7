Normal: 
            UT1: Addition (0, 0) -> Zero + Zero -> check case Addition Zero.
            UT2: Addition (-2, 1) -> Negative + Positive -> check case Addition Negative.
            UT3: Addition (-2, -1) -> Negative + Negative -> check case Addition Negative.
            UT4: Addition (3, -1) -> Positive + Negative -> check case Addition Positive.
            UT5: Addition (3, 3) -> Positive + Negative -> check case Addition Positive.
            UT6: Addition (3, 0) -> Positive + Zero -> check case Addition Positive.
            UT7: Addition (-3, 0) -> Negative + Zero -> check case Addition Negative.

Abnormal:
            UT8: Addition (-32767, -5) -> Negative + Negative -> check case Addition out of range Negative.
            UT9: Addition (32766, 10) -> Positive + Positive -> check case Addition out of range Positive.

Boundary: check giá tr? biên n, n-1, n+1
            UT10: Addition (-32768, 0) -> n + Zero -> check case Addition Negative Boundary (n).
            UT11: Addition (-32760, -8) -> Negative + Negative -> check case Addition Negative Boundary (n).
	    UT12: Addition (32767, 0) -> n + Zero -> check case Addition Positive Boundary (n).
            UT13: Addition (32760, 7) -> Positive + Positive -> check case Addition Positive Boundary (n).
	    UT14: Addition (-32768, 32767) -> n + n.
	