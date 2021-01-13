import React from 'react';

function TestBox({valid, testId}) {
    return (
        <div className={`testbox testbox-${valid ? 'valid' : 'invalid'}`}>
            <span>
                {
                    testId
                }
            </span>
            <span>
                {
                    valid 
                    ? "Valid"
                    : "Test esuat"
                }
            </span>
        </div>
    );
}

export default TestBox;